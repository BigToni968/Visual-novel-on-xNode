using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public interface IViewPortrait
{
    public void Show(string name, Sprite sprite, Position position);
}

public class PortraitBox
{
    public PortraitBox(string name, Image image, Position position)
    {
        Name = name;
        Image = Image;
        Position = position;
    }

    public string Name { get; set; }
    public Image Image { get; set; }
    public Position Position { get; set; }
}

public class PortraitView : MonoBehaviour, IViewPortrait
{
    [SerializeField] private Image _prefab;
    [SerializeField] private Transform[] _position;

    private List<PortraitBox> _characters;
    private Color[] _colors;

    private void Start()
    {
        _characters = new List<PortraitBox>(_position.Length);
        _colors = new Color[2] { new Color(1, 1, 1, 1), new Color(1, 1, 1, 0) };
        //_color[0] == show! _color[1] == hide!
    }

    public void Show(string name, Sprite sprite, Position position)
    {
        PortraitBox box = new PortraitBox(name, null, position);

        if (!Replace(box, out PortraitBox existing))
        {
            Image image = Instantiate(_prefab, _position[(int)box.Position]);
            image.name = box.Name;
            image.sprite = sprite;
            image.color = _colors[0];
            box.Image = image;

            _characters.Add(box);
        }
        else
        {
            existing.Image.sprite = sprite;
            existing.Image.transform.position = _position[(int)existing.Position].position;
        }
    }

    private bool Replace(PortraitBox box, out PortraitBox existingBox)
    {
        existingBox = null;

        for (int i = 0; i < _characters.Count; i++)
        {
            if (box.Name == _characters[i].Name && box.Position != _characters[i].Position)
            {
                _characters[i].Position = box.Position;
                existingBox = _characters[i];
                return true;
            }
        }

        return false;
    }
}