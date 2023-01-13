grammar Calculator;

// Rules
body: expression EOF;

expression: NUMBER
    | expression op=ADD expression
    | expression op=SUBTRACT expression
    | expression op=MULTIPLY expression
    | expression op=DIVIDE expression
    | PAREN_OPEN expression PAREN_CLOSE;

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