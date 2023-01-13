grammar Calculator;

// Rules
body: expression EOF;

expression: NUMBER
    | NUMBER ADD NUMBER
    | NUMBER SUBTRACT NUMBER
    | NUMBER MULTIPLY NUMBER
    | NUMBER DIVIDE NUMBER;

// Tokens
NUMBER: '-'? DIGIT+;

ADD: '+';
SUBTRACT: '-';
MULTIPLY: '*';
DIVIDE: '/';

PAREN_OPEN: '(';
PAREN_CLOSE: ')';

// Fragments
fragment DIGIT: [0-9];

// Ignore whitespace
WHITESPACE  : (' ' | '\t')+ -> skip;
NEWLINE     : ('\r'? '\n' | '\r')+ -> skip;