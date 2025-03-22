public class Word {
    private string _text { get; set; }
    private bool _isHidden { get; set; }

    public Word(string text) {
        _text = text;
        _isHidden = false;
    }

    public void Hide() {
        _isHidden = true;
    }

    public void Show() {
        _isHidden = false;
    }

    public bool IsHidden() {
        return _isHidden;
    }

    public string GetDisplayText() {
        if (_isHidden) {
            return new string('_', _text.Length);
        }
        return _text;
    }
}