using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Upletter.Models;

namespace Upletter.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Word> Words { get; set; }
        public List<string> WordList = new List<string>() { " " };
        public IndexModel(DataContext dbContext)
        {
            Words = dbContext.Words;
        }

        public string Message { get; set; } = 
        @"���� ��������� � ��� ������� �� ���� � �� ����� The Wiki Way: Quick Collaboration on the Web ������� �������� ��������� ���� ��������� �������:
        ���� ���������� ���� ������������� ������������� ����� �������� ��� ��������� ����� �������� �� ����-�����, ��������� ������� ���-������� ��� �����-���� ��� ����������.
        ���� ������������ ����� ����� ������� ���������� �� ���� ����� ���������� ��������� �������� ������ �� ������ �������� � ����������� ����, ���������� ������ �������� ��� ���.
        ���� �� �������� ��������� ������������� ������ ��� ��������� �����������. ��������, ���� ��������� �������� ����������� � ������������ �������� �������� � ��������������, ������� ��������� ������ ��� �����.
        ";
        public char[] SentenceSeparators { get; set; } = { '.', '!', '?' };
        public char[] Separators { get; set; } = { ' ', ';', ':', ',' };

        public void OnGet() {}
        public void OnPost(string text)
        {
            if (text != null)
            {
                var WordArr = GetWords(text).ToArray();
                Array.Sort(WordArr);
                WordList = WordArr.Distinct().ToList();
                Message = GetNewText(text);
            }
            else
            {
                Message = "";
                WordList.Add("");
            }
        }
        public List<string> GetWords(string text)
        {
            WordList.Clear();
            var temp = text.Split(SentenceSeparators, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
            for (var i = 0; i < temp.Length; i++)
            {
                var temp2 = temp[i].Split(Separators, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
                for (var j = 1; j < temp2.Length; j++)
                {
                    var ch = temp2[j];
                    if (char.IsUpper(ch[0]))
                    {
                        var flag = false;
                        foreach (var word in Words)
                        {
                            if (temp2[j] == word.Meaning)
                            {
                                flag = true;
                            }
                        }
                        if (flag == false)
                        {
                            WordList.Add(temp2[j]);
                        }
                    }
                }
            }
            return WordList;
        }
        public string GetNewText(string text)
        {
            var tempText = new StringBuilder();
            tempText.Append(text);
            foreach (var word in Words)
            {
                if(text.IndexOf(word.Meaning.ToLower(), 0, text.Length) != -1)
                {
                    tempText.Remove(text.IndexOf(word.Meaning.ToLower(), 0, text.Length), word.Meaning.Length);
                    tempText.Insert(text.IndexOf(word.Meaning.ToLower()), word.Meaning);
                }
            }
            return tempText.ToString();
        }
    }
}
