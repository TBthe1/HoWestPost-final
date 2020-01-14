using System;
using System.Threading;

namespace HoWestPost.Domain
{
    public class DeliveryProcessor
    {
        //TODO proces deliveries...

        Thread PackageProcessor = new Thread(CheckForNewPackages);

        private static void CheckForNewPackages(object obj)
        {
            //Let this thread constantly check for new packages
            //If new package is made, put it in 
        }



        

        //PackageProcessor.start();

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



    }
}
