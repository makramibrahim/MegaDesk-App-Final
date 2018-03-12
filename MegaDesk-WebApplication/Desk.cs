using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaDesk_WebApplication
{
    public class Desk
    {
        public double Width { get; set; }
        public double Depth { get; set; }
        public int NumOfDrawers { get; set; }
        public SurfaceMaterials SurfMaterials { get; set; }

        public const double MIN_WIDTH = 24;
        public const double MAX_WIDTH = 96;
        public const double MIN_DEPTH = 12;
        public const double MAX_DEPTH = 48;
    }

    /***********************
     * Set our own data type 
     **********************/
    public enum SurfaceMaterials
    {
        Laminate = 100,
        Oak = 200,
        Rosewood = 300,
        Veneer = 125,
        Pine = 50
    }


    public class DeskQuote
    {
        /*************************
        * Declare some variables 
        *************************/
        public String ClientName { get; set; }
        public DateTime QuoteDate { get; set; }
        public int RushDays { get; set; }
        public Desk Desk = new Desk();
        public double QuotePrice { get; set; }


        private double Surface = 0;


        //Priced items with fiexed values
        private const int BASE_PRICE = 200;
        private const int BASE_SIZE = 1000;
        private const int DRAWER_PRICE = 50;
        private const int PRICE_PER_INCH = 1;
        private const int RUSH_DAYS1 = 3;
        private const int RUSH_DAYS2 = 5;
        private const int RUSH_DAYS3 = 7;
        private const int RUSH_HOLD = 2000;

        /******************************
        * Overloaded Constructor
        * ***************************/
        public DeskQuote(string name, DateTime quoteDate, double width, double depth,
            int drawers, SurfaceMaterials material, int rushDays)
        {
            ClientName = name;
            QuoteDate = quoteDate;
            Desk.Width = width;
            Desk.Depth = depth;
            Desk.SurfMaterials = material;
            Desk.NumOfDrawers = drawers;
            RushDays = rushDays;

            Surface = Desk.Width * Desk.Depth;
        }

        /*******************************
       * Defalut Constructor
       * ***************************/
        public DeskQuote() { }


        /************************************
       * Display the desk surface area
       * **********************************/
        public double CalQuoteTotal()
        {
            return BASE_PRICE + SurfaceArea() + DrawerCost() + (int)Desk.SurfMaterials + RushOrderCost();
        }

        private double SurfaceArea()
        {
            double extraSurfaceCost = 0;
            if (Surface > BASE_SIZE)
            {
                extraSurfaceCost = (Surface - BASE_SIZE) * PRICE_PER_INCH;

            }
            return extraSurfaceCost;
        }

        private double DrawerCost()
        {
            return Desk.NumOfDrawers * DRAWER_PRICE;
        }

        /************************************
        * Get Rush Days cost. 
        ***********************************/
        public int RushOrderCost()
        {
            int rushDays = 0;
            if (Surface < BASE_SIZE)
            {
                if (RushDays == RUSH_DAYS1)
                {
                    rushDays = 60;
                }
                else if (RushDays == RUSH_DAYS2)
                {
                    rushDays = 40;
                }
                else if (RushDays == RUSH_DAYS3)
                {
                    rushDays = 30;
                }
                else
                {
                    rushDays = 0;
                }
            }
            else if (Surface > BASE_SIZE || Surface < 2000)
            {
                if (RushDays == RUSH_DAYS1)
                {
                    rushDays = 70;
                }
                else if (RushDays == RUSH_DAYS2)
                {
                    rushDays = 50;
                }
                else if (RushDays == RUSH_DAYS3)
                {
                    rushDays = 35;
                }
                else
                {
                    rushDays = 0;
                }
            }

            else
            {
                if (RushDays == RUSH_DAYS1)
                {
                    rushDays = 80;
                }
                else if (RushDays == RUSH_DAYS2)
                {
                    rushDays = 60;
                }
                else if (RushDays == RUSH_DAYS3)
                {
                    rushDays = 40;
                }
                else
                {
                    rushDays = 0;
                }
            }

            return rushDays;

        }
    }



}