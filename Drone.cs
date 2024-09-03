using System;
using System.Runtime.CompilerServices;

namespace Drone {

    public class Drone {

        public double Height {get; set;}
        public int Angle {get; set;}
        public double Speed {get; set;}
        public bool Approximation {get; set;}
        public void Fly (double height) {
            this.Height += height;
        }
        
        public void Direction (int direction) {
            this.Angle += direction;
        }
        
        public void MoveVelocity (double speed) {
            this.Speed += speed;
        }

        public void ApproxObj (bool approximation) {
            approximation = true;
            this.Approximation = approximation;
        }   
    }

}