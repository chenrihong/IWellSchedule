using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Quartz;

namespace IWellSchedule
{
    public class QuartzGenerateXML
    {
        /// <summary>
        /// 配置文件 quartz_jobs.xml
        /// </summary>
        private string quartz_jobs_xml_file
        {
            get
            {
                string file = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
                file += "quartz_jobs.xml";

                return file;
            }
        }


        public void GenerateXML()
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(dec);

            //创建一个根节点（一级）
            XmlElement root = doc.CreateElement("job-scheduling-data");
            root.SetAttribute("xmlns", "http://quartznet.sourceforge.net/JobSchedulingData");
            root.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            root.SetAttribute("version", "2.0");
            doc.AppendChild(root);

            //创建节点（二级）
            XmlElement node = doc.CreateElement("processing-directives");
            //创建节点（三级）
            XmlElement element1 = doc.CreateElement("overwrite-existing-data");
            element1.InnerText = "true";
            node.AppendChild(element1);

            //创建节点（二级）


            root.AppendChild(node);

            XmlElement node_schedule = GetScheduleNode(doc);
            if (node_schedule != null)
            {
                root.AppendChild(node_schedule);
                doc.Save(quartz_jobs_xml_file);
            }
        }

        private XmlElement GetScheduleNode(XmlDocument doc)
        {

            XmlElement node_schedule = doc.CreateElement("schedule");

            DataTable dt = new QuartzJobs().GetValidData();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("生成失败，没有数据或数据状态均为0", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                node_schedule.AppendChild(createJobElement(dr, doc));
                node_schedule.AppendChild(createTriggerElement(dr, doc));
            }


            MessageBox.Show("一共生成了" + dt.Rows.Count + "条job!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return node_schedule;
        }

        private XmlElement createJobElement(DataRow dr, XmlDocument doc)
        {
            XmlElement job = doc.CreateElement("job");

            StringBuilder sb = new StringBuilder();

            string namespaceName = dr["命名空间"].ToString();
            string className = dr["类"].ToString();

            sb.AppendLine("<name>" + className + "</name>");
            sb.AppendLine("<group>" + namespaceName + "</group>");
            sb.AppendLine("<description>描述</description>");
            sb.AppendLine("<job-type>" + className + "," + namespaceName + "</job-type>");

            sb.AppendLine("<durable>true</durable>");
            sb.AppendLine("<recover>false</recover>");

            job.InnerXml = sb.ToString();

            return job;
        }

        private XmlElement createTriggerElement(DataRow dr, XmlDocument doc)
        {
            XmlElement trigger = doc.CreateElement("trigger");

            XmlElement cron = doc.CreateElement("cron");

            StringBuilder sb = new StringBuilder();

            string namespaceName = dr["命名空间"].ToString();
            string className = dr["类"].ToString();

            string timepices = dr["时间片"].ToString();// 3秒 = 0/3 * * * * ?

            sb.AppendLine("<name>tg." + className + "</name>");
            sb.AppendLine("<group>tgg." + namespaceName + "</group>");
            sb.AppendLine("<description>描述</description>");
            sb.AppendLine("<job-name>" + className + "</job-name>");
            sb.AppendLine("<job-group>" + namespaceName + "</job-group> ");
            sb.AppendLine("<cron-expression>"+ timepices +"</cron-expression>");

            cron.InnerXml = sb.ToString();
            trigger.AppendChild(cron);

            return trigger;
        }

    }
}
