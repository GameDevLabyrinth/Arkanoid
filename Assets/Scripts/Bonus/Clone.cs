namespace GameDevLabirinth
{
    public class Clone : Bonus
    {
        public override void Apply()
        {
            BallCreator ballCreator = GetComponentInParent<BallCreator>();
            if (ballCreator != null)
            {
                ballCreator.CreateClone();
            }
            Destroy(gameObject);
        }
    }
}