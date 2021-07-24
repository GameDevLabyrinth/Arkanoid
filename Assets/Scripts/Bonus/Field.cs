namespace GameDevLabirinth
{
    public class Field : Bonus, IRemovable
    {
        private FieldInScene _fieldInScene;

        private void OnEnable()
        {
            if (_fieldInScene == null)
            {
                _fieldInScene = FindObjectOfType<FieldInScene>();
            }
        }

        public override void Apply()
        {
            _fieldInScene.SetActive(true);
            StartTimer();
        }

        public void Remove()
        {
            _fieldInScene.SetActive(false);
        }
    }
}