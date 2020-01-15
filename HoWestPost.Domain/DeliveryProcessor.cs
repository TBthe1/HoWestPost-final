using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

//EXPLANATION

//The delivery processor = an object that takes a list, prioritizes the elements, and generates the packages (prof)
//Each item in this project has its own responsibility 

//GENERAL IDEA

//Avoiding the FIFO scheduling because we're working with a priority button (fifo causes starvation)
//(Use FPPS (fixed priority pre-emptive scheduling) to give each process a fixed priority)
//Based on those fixed priorities, put normal deliveries in a "row", put prioritized deliviries in a different "row"
//The normal deliveries are in a different row/list and don't have to wait longer on the prioritized deliveries (avoid starvation) 
//If a delivery in the normal "row" has a "long" wait time --> make it a priority, so it gets put in the priority "row" (pre-emptive scheduling)
//This way, priorities are kept on the prioritized deliveries, and long waiting deliveries don't get too much behind schedule (starvation is avoided) 
//Determine if a normal delivery is waiting "long" or not with the "Highest response ratio next" scheduling
//--> (waiting time + estimated run time) / estimated run time = 1 + (waiting time / estimated run time)
//The jobs that have spent a long time waiting compete against those estimated to have short run times


//TIPS
//Constructor and methodes can call other classes in their scope

namespace HoWestPost.Domain
{
    public static class DeliveryProcessor
    {

        #region Fields
        private static Stopwatch timer = new Stopwatch();
        private static List<Delivery> deliveryList;
        private static bool Processing = false;
        private static event Action StartProcessing;

        public static event Action RefreshList;
        public static event Action ShowDeliveryData;
        public static event Action RemoveDeliveryData;

        public static event Action<string, double,double> ProgressUpdated;
        public static event Action<int> IdUpdated;
        #endregion

        #region Constructor
        static DeliveryProcessor()
        {
            StartProcessing += DeliveryProcessor_Process;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Starts the DeliveryProcessor
        /// </summary>
        public static void Start(ref List<Delivery> deliveries)
        {
            if (Processing) return;

            Processing = true;

            deliveryList = deliveries;

            StartProcessing?.Invoke();
        }

        /// <summary>
        /// Stops the DeliveryProcessor
        /// </summary>
        public static void Stop()
        {

        }
        #endregion


        #region Private Methods
        private static TimeSpan ElapsedTime => TimeSpan.FromMilliseconds(timer.ElapsedMilliseconds);

        /// <summary>
        /// Main loop of the Processor
        /// </summary>
        private static void DeliveryProcessor_Process()
        {
            Thread DeliveryProcessorThread = new Thread(Process);
            DeliveryProcessorThread.Start();
        }

        private static void Process()
        {
            Console.WriteLine("Processing Started");

            Delivery currentDeliveryStart = deliveryList[0];

            ShowDeliveryData?.Invoke();
            IdUpdated?.Invoke(currentDeliveryStart.Id);

            while (deliveryList.Count != 0)
            {
                timer.Start();

                Delivery currentDelivery = deliveryList[0];
                DeliveryService.EvaluatePriorities(ElapsedTime);

                RemoveDeliveryData?.Invoke();
                IdUpdated?.Invoke(currentDelivery.Id);
                ShowDeliveryData?.Invoke();

                Console.WriteLine($"Delivering ID: {currentDelivery.Id}");

                //double additionalTimeFactor;

                //if (currentDelivery.PackageType == PackageType.Mini)
                //{
                //    additionalTimeFactor = 1;
                //}
                //else if (currentDelivery.PackageType == PackageType.Standaard)
                //{
                //    additionalTimeFactor = 1.2;
                //}
                //else
                //{
                //    additionalTimeFactor = 1.5;
                //}

                int waitTimeMilliseconds = (int)(((currentDelivery.TravelTime)) * 100);

                double timeFactor = (double)3.6 * ((currentDelivery.TravelTime)/(double)10);

                double progressValue = ((double)10 / ((double)waitTimeMilliseconds))* 2;


                //GUI freezes

                //Task deliveryThread = Task.Run(() => Deliver(elapsedTime, waitTimeMilliseconds));
                //deliveryThread.Wait(waitTimeMilliseconds);

                //Task remainingTimeThread = Task.Run(() => RemainingTime(elapsedTime, waitTimeMilliseconds));
                //remainingTimeThread.Wait(waitTimeMilliseconds);

                //GUI freezes

                while (timer.ElapsedMilliseconds < waitTimeMilliseconds)
                {
                    string currentInfo = "Pakket is onderweg!";
                    int elapsedTime = (int)timer.ElapsedMilliseconds;
                    int remainingTime = (waitTimeMilliseconds - elapsedTime);
                    ProgressUpdated?.Invoke(currentInfo, progressValue, remainingTime);
                }

                Console.WriteLine($"Finished ID {currentDelivery.Id} in {currentDelivery.TravelTime} min");

                deliveryList.RemoveAt(0);
                RefreshList?.Invoke();

                RemoveDeliveryData?.Invoke();
                IdUpdated?.Invoke(currentDelivery.Id);
                ShowDeliveryData?.Invoke();

                timer.Reset();
                timer.Stop();
            }

            string packageGone = "Er is geen pakket onderweg.";

            ProgressUpdated?.Invoke(packageGone, 0, 0);

            RemoveDeliveryData?.Invoke();

            Console.WriteLine("Processing Stopped");

            Processing = false;
        }


        /// <summary>
        /// Delivery and Remaining time Thread --> make gui freeze 
        /// </summary>
        //private static void Deliver(int elapsedTime, int waitTimeMilliseconds)
        //{
        //    while (elapsedTime < waitTimeMilliseconds)
        //    {
        //        double progressValue = (double)100 / (double)waitTimeMilliseconds;

        //        ProgressUpdated?.Invoke(progressValue);
        //    }
        //}

        //private static void RemainingTime(int elapsedTime, int waitTimeMilliseconds)
        //{
        //    while (elapsedTime < waitTimeMilliseconds)
        //    {
        //        double remainingTime = (double)waitTimeMilliseconds - (double)elapsedTime;

        //        UpdateRemainingTime?.Invoke(remainingTime);
        //    }
        //}
        #endregion
    }
}
