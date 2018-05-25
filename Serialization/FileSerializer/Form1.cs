using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyUtilities
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RunExample();
        }

        public void RunExample()
        {
            Car car1 = new Car("Ford", "Mustang GT", 2007);
            Car car2 = new Car("Dodge", "Viper", 2006);
            car1.Owner = new Owner("Rich", "Guy");
            car2.Owner = new Owner("Very", "RichGuy");

            //save cars individually
            FileSerializer.Serialize(@"Car1.dat", car1);
            FileSerializer.Serialize(@"Car2.dat", car2);

            //save as a collection
            Cars cars = new Cars();
            cars.Add(car1);
            cars.Add(car2);
            FileSerializer.Serialize(@"Cars.dat", cars);

            //now read them back in
            Car savedCar1 = FileSerializer.Deserialize<Car>(@"Car1.dat");
            Car savedCar2 = FileSerializer.Deserialize<Car>(@"Car2.dat");

            //and for the collection�
            Cars savedCars = FileSerializer.Deserialize<Cars>(@"Cars.dat");
        }

    }

}