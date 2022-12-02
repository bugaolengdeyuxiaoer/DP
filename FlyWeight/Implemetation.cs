using System;
using System.Collections.Generic;
using System.Threading;

namespace FlyWeight
{

    public interface ICharacter
    {
        void Draw(string fontFamily, int fontSize);
    }
    
    public class CharacterA : ICharacter
    {
        private char _actualCharacter = 'a';
        private string _fontFamily = string.Empty;
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;
            Console.WriteLine($"Drawing {_actualCharacter}, {_fontFamily} {_fontSize}");
        }
    }

    public class CharacterB : ICharacter
    {
        private char _actualCharacter = 'b';
        private string _fontFamily = string.Empty;
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;
            Console.WriteLine($"Drawing {_actualCharacter}, {_fontFamily} {_fontSize}");
        }
    }

    public class CharacterFactory
    {
        private readonly Dictionary<char, ICharacter> _characters = new Dictionary<char, ICharacter>();

        public ICharacter? GetCharacter(char characterIdentifier)
        {
            if (_characters.ContainsKey(characterIdentifier))
            {
                Console.WriteLine("Character reuse");
                return _characters[characterIdentifier];
            }
            Console.WriteLine("character construction");
            switch (characterIdentifier)
            {
                case 'a':
                    _characters[characterIdentifier] = new CharacterA();
                    return _characters[characterIdentifier];
                case 'b':
                    _characters[characterIdentifier] = new CharacterB();
                    return _characters[characterIdentifier];
            }
            return null;
        }

        public ICharacter CreateParagraph(List<ICharacter> characters, int location)
        {
            return new Paragraph(characters, location);
        }
    }
    
    public class Paragraph :ICharacter
    {
        private int _location;
        private List<ICharacter> _characters = new List<ICharacter>();

        public Paragraph(List<ICharacter> characters ,int location)
        {
            _characters = characters;
            _location = location;
        }

        public void Draw(string fontFamily,int fontSize)
        {
            Console.WriteLine($"Drawing in paragraph at location {_location}");
            foreach(var character in _characters)
            {
                character.Draw(fontFamily, fontSize);
            }
        }
    }
}
