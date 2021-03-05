namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }

        public string ShininessDescription()
        {
            if (this.ShininessLevel < 2)
            {
                return "dull";
            }
            else if (this.ShininessLevel >= 2 && this.ShininessLevel <= 5)
            {
                return "noticable";
            }
            else if (this.ShininessLevel >= 6 && this.ShininessLevel <= 9)
            {
                return "bright";
            }
            else
            {
                return "blinding";
            }
        }
    }
}