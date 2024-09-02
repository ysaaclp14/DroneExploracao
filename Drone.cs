using System;
using System.Runtime.CompilerServices;

namespace Drone {

    public class Drone {

        public double Height {get; set;}

        public void Fly (double altura) {
            this.Height += altura;
        }
       
    }

}