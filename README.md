<h1>Find the Largest Anagram Set</h1> 
<h2>(Functional & Imperative Methods)</h2>

<h3> Technology: C#, .Net Core 3.1, LINQ </h3>
 
<h3>Description</h3>
This program takes a list of words and finds the biggest set of words
within that list that are anagrams of each other. If this process
finds that there is more than one set of anagrams that meet this requirement
then the last found set is returned.

There are two approaches taken to find the largest set of anagrams

     1. LargestAnagramListFunctional() - extension method using functional code (LINQ)
     2. LargestAnagramList()           - extension method using imperative code

<h3>Build</h3>

    dotnet restore

    dotnet build --configuration Release

<h3>Run</h3>

    dotnet run

<h3>Output</h3>

    ABC
    ACB
    BAC
    CAB