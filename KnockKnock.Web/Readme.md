KnockKnock
=========

Web API project which implements several code challenges, all challenges can be queried through the API using HTTP Get. 

### External API Usage
+ **Fibonacci**:
Returns the nth number in the fibonacci sequence.

`n = The index (n) of the fibonacci sequence`

Ie.

```
/api/Fibonacci?n=10
```

+ **ReverseWords**:
Reverses the letters of each word in a sentence.

`sentence = the sentence you would like to reverse.`

Ie.
```
/api/ReverseWords?sentence=never%20ever%20should%20you%20reverse%20this
```

+ **Triangle Type**:
Returns the type of triange given the lengths of its sides

`a = The length of side a`

`b = The length of side b`

`c = The length of side c`

Ie.
```
/api/TriangleType?a=2&b=3&c=4
```

### Local Usage
	
+ **Fibonacci**:
```
// Instantiation
IFibonacciService fibService = new FibonacciService();
FibonacciController fibController = new FibonacciController(fibService);

// Retrieve Value
int nthValue = 10;
var result = fibController.Get(nthValue);
```

+ **ReverseWords**:
```
// Instantiation
IReverseWordService reverseWordService = new ReverseWordService();
ReverseWordsController reverseWordsController = new ReverseWordsController(reverseWordService);

// Retrieve Value
string sentenceToReverse = "reverse this sentence";
var result = reverseWordsController.Get(sentenceToReverse);
```

+ **Triangle Type**:
```
// Instantiation
ITriangleTypeService triangleTypeService = new TriangleTypeService();
TriangleTypeController triangleTypeController = new TriangleTypeController(triangleTypeService);

// Retrieve Value
int aLength = 2;
int bLength = 3;
int cLength = 4;
var result = triangleTypeController.Get(aLength, bLength, cLength)
```

### Hidden Easter Egg

If you know about this project, you will know the url to query for this easter egg :)

© MikeDub - 2018