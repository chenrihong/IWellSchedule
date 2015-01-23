﻿using System;

using Common.Logging;
using Quartz;
using Quartz.Impl; 

namespace IWellSchedule
{
	/// <summary>
	/// The main server logic.
	/// </summary>
	public class QuartzServer : IQuartzServer
	{
		private readonly ILog logger;
		private ISchedulerFactory schedulerFactory;
		private IScheduler scheduler;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuartzServer"/> class.
        /// </summary>
	    public QuartzServer()
	    {
	        logger = LogManager.GetLogger(GetType());
	    }

	    /// <summary>
		/// Initializes the instance of the <see cref="QuartzServer"/> class.
		/// </summary>
		public virtual void Initialize()
		{
			try
			{				
				schedulerFactory = CreateSchedulerFactory();
				scheduler = GetScheduler();
			}
			catch (Exception e)
			{
				logger.Error("服务初始失败:" + e.Message, e);
				throw;
			}
		}

        /// <summary>
        /// Gets the scheduler with which this server should operate with.
        /// </summary>
        /// <returns></returns>
	    protected virtual IScheduler GetScheduler()
	    {
	        return schedulerFactory.GetScheduler();
	    }

        /// <summary>
        /// Returns the current scheduler instance (usually created in <see cref="Initialize" />
        /// using the <see cref="GetScheduler" /> method).
        /// </summary>
	    protected virtual IScheduler Scheduler
	    {
	        get { return scheduler; }
	    }

	    /// <summary>
        /// Creates the scheduler factory that will be the factory
        /// for all schedulers on this instance.
        /// </summary>
        /// <returns></returns>
	    protected virtual ISchedulerFactory CreateSchedulerFactory()
	    {
	        return new StdSchedulerFactory();
	    }

	    /// <summary>
		/// Starts this instance, delegates to scheduler.
		/// </summary>
		public virtual void Start()
		{
	        try
	        {
	            scheduler.Start();
	        }
	        catch (Exception ex)
	        {
	            logger.Fatal(string.Format("调度器启动失败 {0}", ex.Message), ex);
	            throw;
	        }

            logger.Info("调度器启动成功");
		}

		/// <summary>
		/// Stops this instance, delegates to scheduler.
		/// </summary>
		public virtual void Stop()
		{
            try
            {
                scheduler.Shutdown(true);
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("调度器关闭失败 {0}", ex.Message), ex);
                throw;
            }

            logger.Info("调度器关闭完成");
		}

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
	    public virtual void Dispose()
	    {
	        // no-op for now
	    }

        /// <summary>
        /// Pauses all activity in scheduler.
        /// </summary>
	    public virtual void Pause()
	    {
	        scheduler.PauseAll();
	    }

        /// <summary>
        /// Resumes all activity in server.
        /// </summary>
	    public void Resume()
	    {
	        scheduler.ResumeAll();
	    }
	}
}
