/******************************************************************************
 *************************     ADNAN OQUAISH     ******************************
 **************************     BITS Pilani     *******************************
 ******************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.data;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
//using Stem;
//using System.Runtime.InteropServices;

namespace SimpleTermFrequencyAnalyser
{
	class Program
	{
		static void Main(string[] args)
		{
			// Read a file into a string (this file must live in the same directory as the executable)
			string filename;
			Console.WriteLine(" ******************** Adnan Oquaish  ************************** \n");
//			int kasd;
			//for(kasd =0 ;kasd<5;kasd++)
			{
			Console.WriteLine(" Please enter the name of user text file in the same directory : ");
			filename = Console.ReadLine();
			string inputString = File.ReadAllText(filename);
			
			// Convert our input to lowercase
			inputString = inputString.ToLower();        

			// Define characters to strip from the input and do it
			string[] stripChars = { ";", ",", ".", "-", "_", "^", "(", ")", "[", "]","{","}","\\","\"","/","=","!","@","#","$","%","+","&","*",
						"'","'s","`","|",":","~","0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "\n", "\t", "\r" };
						
			foreach (string character in stripChars)
			{
				inputString = inputString.Replace(character, "");
			}
			
			// Split on spaces into a List of strings
			List<string> wordList = inputString.Split(' ').ToList();
			// Define and remove stopwords
			
			stopwords sw = new stopwords();
			foreach (string word in sw.stop)
			{
				while ( wordList.Contains(word) )
				{
					wordList.Remove(word);
				}
			}
			
			// Create a new Dictionary object
			Dictionary<string, int> dictionary = new Dictionary<string, int>();

			// Loop over all over the words in our wordList...
			foreach (string word in wordList)
			{
				// If the length of the word is at least three letters...
				if (word.Length >= 3) 
				{
				//	Chk = word.Substring(0,word.Length-1) ;
					// ...check if the dictionary already has the word.
					if ( dictionary.ContainsKey(word))
					{
						// If we already have the word in the dictionary, increment the count of how many times it appears
						dictionary[word]++;
					}
					//else if (dictionary.ContainsKey(Chk) )
///					{
///						dictionary[Chk]++;
///					}
					else
					{
						// Otherwise, if it's a new word then add it to the dictionary with an initial count of 1
						dictionary[word] = 1;
					}

				} // End of word length check

			} // End of loop over each word in our input

			// Create a dictionary sorted by value (i.e. how many times a word occurs)
			var sortedDict = (from entry in dictionary orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
			int count = 1;
			
			Stemmer st = new Stemmer ();
			
				int qwe =0;
				foreach (KeyValuePair<string,int> s in sortedDict)
				{
					if(qwe++ >= 50)break;
					else
						s.Key.Replace(s.Key,st.stemTerm(s.Key));
				}		
			
			Console.WriteLine("\n----  Top 10 Tags & Occurence of the User : " + filename + " are :----");
			Console.WriteLine();
			foreach (KeyValuePair<string, int> pair in sortedDict)
			{
				// Output the most frequently occurring words and the associated word counts
				Console.WriteLine(count + "\t" + pair.Key + "\t" + (double)(pair.Value));
				count++;

				// Only display the top 10 words then break out of the loop!
				if (count > 10)
				{
					break;
				}
			}

			// Wait for the user to press a key before exiting
			Console.ReadKey();
			}
		} // End of Main method

	} // End of Program class

} // End of namespace
