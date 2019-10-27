namespace PracaDyplomowa.Mobile.Logic
{
    public class LabelingGame
    {
        public GameState State { get; private set; }
        public LabelItem[] BoardItems { get; set; }
        public int CurrentLabelItem { get; set; }

        public LabelingGame()
        {

        }

        
    }

    public enum GameState
    {
        Initialize,
        InProgress,
        GameOver
    }

    public class LabelItem
    {
        public string Label { get; set; }
        public string ImageUri { get; set; }
    }
}
