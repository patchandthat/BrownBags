grammar Calculator;

// Rules
body: expression EOF;

expression: NUMBER
    | PAREN_OPEN expression PAREN_CLOSE
    | expression op=MULTIPLY expression
    | expression op=DIVIDE expression
    | expression op=ADD expression
    | expression op=SUBTRACT expression;

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