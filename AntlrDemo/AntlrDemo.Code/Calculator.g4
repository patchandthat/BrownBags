grammar Calculator;

// Rules
body: EOF;


// Tokens
NUMBER: '-'? DIGIT+;

// Fragments
fragment DIGIT: [0-9];

// Ignore whitespace
WHITESPACE  : (' ' | '\t')+ -> skip;
NEWLINE     : ('\r'? '\n' | '\r')+ -> skip;