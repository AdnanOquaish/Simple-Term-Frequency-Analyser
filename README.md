# Simple-Term-Frequency-Analyser

## Overview
This is a simple piece of code that takes in a corpus of text and gives out the most occuring number of words. It also removes the Stopwords (Adverbs, Articles, Numerals, Punctuation & Pronouns) and any non-alphabetical characters. It also employs a Porter Stemmer which converts a word to its base form. (i.e The base form for Iteration, Iterated, Iterating and Iterates is "Iterate"). Thereby, it ensures no false counting for words.

## Uses
This code can be used to take the number of occurences of the words and feed them into a Tf-Idf weighter to act on a collection of documents. This would have a lot of application in any text-processing scenario.
  I personally used it to create a Tf-Idf dictionary which was then used in converting a set of text documents to Vector Space Model upon which I used Cosine Similarity to find k-Nearest Neighbours as a part of a Recommendation Engine that I was building.

## Note
Since this code can be used to extract the Topic or a set of "Tags" of the Text Corpus (by finding the most frequently occuring non-stopwords). Most of the Stopwords Do not contribute any real meaning to the tags of the corpus, hence need to be removed.

To compile and run in Ubuntu, Debian ensure that dmcs and mono are installed. Then : 
  $ dmcs Main.cs StopWords.cs Stemmer.cs
  $ mono Main.exe
