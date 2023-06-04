using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1.UI;

namespace P1.BL
{
    class Ghost
    {
        public int x;
        public int y;
        public string ghostDirection;
        public char ghostCharacter;
        public float speed;
        public char previousItem;
        public float deltaChange;
        public Grid mazeGrid;
        public Ghost(int x, int y, string ghostDirection, char ghostCharacter, float speed, char previousItem, Grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.ghostDirection = ghostDirection;
            this.ghostCharacter = ghostCharacter;
            this.speed = speed;
            this.previousItem = previousItem;
            this.mazeGrid = mazeGrid;
        }
        public void SetDirection(string ghostDirection)
        {
            this.ghostDirection = ghostDirection;
        }
        public string GetDirection()
        {
            return ghostDirection;
        }
        public void Remove()
        {
            GhostUI.Remove(this.x, this.y);
        }
        public void Draw()
        {
            GhostUI.Draw(this.ghostCharacter, this.x, this.y);
        }
        public char GetCharacter()
        {
            return this.ghostCharacter;
        }
        public void ChangeDelta()
        {
            deltaChange += speed;
        }
        public float GetDelta()
        {
            return deltaChange;
        }
        public void SetDeltaZero()
        {
            deltaChange = 0;
        }
        public void Move()
        {
            ChangeDelta();
            if (Math.Floor(GetDelta()) == 1)
            {
                if (ghostDirection == "Horizontal")
                {
                    MoveHorizontal(mazeGrid);
                }
                SetDeltaZero();
            }
        }
        public void MoveHorizontal(Grid mazeGrid)
        {
            
        }
    }
}
