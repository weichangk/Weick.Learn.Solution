using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern
{
    public enum WordType
    {
        H,
        E,
        L,
        O
    }
    public class FlyweightFactory
    {
        private static Dictionary<WordType, BaseWord> _BaseWordDictionary = new Dictionary<WordType, BaseWord>();
        private static object GetWord_Lock = new object();

        public static BaseWord GetWord(WordType wordType)
        {
            BaseWord baseWord = null;
            if (_BaseWordDictionary.ContainsKey(wordType))//双if+lock
            {
                baseWord = _BaseWordDictionary[wordType];
            }
            else
            {
                lock (GetWord_Lock)
                {
                    if (_BaseWordDictionary.ContainsKey(wordType))
                    {
                        baseWord = _BaseWordDictionary[wordType];
                    }
                    else
                    {
                        switch (wordType)
                        {
                            case WordType.H:
                                baseWord = new H();
                                break;
                            case WordType.E:
                                baseWord = new E();
                                break;
                            case WordType.L:
                                baseWord = new L();
                                break;
                            case WordType.O:
                                baseWord = new O();
                                break;
                            default:
                                throw new Exception("wrong wordType");
                        }
                        _BaseWordDictionary[wordType] = baseWord;
                    }
                }
            }
            return baseWord;
        }

    }
}
