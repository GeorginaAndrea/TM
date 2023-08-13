
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF        =  0, // (EOF)
        SYMBOL_ERROR      =  1, // (Error)
        SYMBOL_WHITESPACE =  2, // Whitespace
        SYMBOL_MINUS      =  3, // '-'
        SYMBOL_EXCLAM     =  4, // '!'
        SYMBOL_LPAREN     =  5, // '('
        SYMBOL_RPAREN     =  6, // ')'
        SYMBOL_TIMES      =  7, // '*'
        SYMBOL_DIV        =  8, // '/'
        SYMBOL_PLUS       =  9, // '+'
        SYMBOL_ENTERO     = 10, // Entero
        SYMBOL_LN         = 11, // ln
        SYMBOL_REAL       = 12, // Real
        SYMBOL_SIN        = 13, // sin
        SYMBOL_SQRT       = 14, // sqrt
        SYMBOL_TAN        = 15, // tan
        SYMBOL_E          = 16, // <E>
        SYMBOL_F          = 17, // <F>
        SYMBOL_FACT       = 18, // <FACT>
        SYMBOL_FUNC       = 19, // <FUNC>
        SYMBOL_LN2        = 20, // <LN>
        SYMBOL_SQRT2      = 21, // <SQRT>
        SYMBOL_T          = 22  // <T>
    };

    enum RuleConstants : int
    {
        RULE_E_PLUS             =  0, // <E> ::= <E> '+' <T>
        RULE_E_MINUS            =  1, // <E> ::= <E> '-' <T>
        RULE_E                  =  2, // <E> ::= <T>
        RULE_T_TIMES            =  3, // <T> ::= <T> '*' <F>
        RULE_T_DIV              =  4, // <T> ::= <T> '/' <F>
        RULE_T                  =  5, // <T> ::= <F>
        RULE_F_LPAREN_RPAREN    =  6, // <F> ::= '(' <E> ')'
        RULE_F_ENTERO           =  7, // <F> ::= Entero
        RULE_F_REAL             =  8, // <F> ::= Real
        RULE_F                  =  9, // <F> ::= <FUNC>
        RULE_F2                 = 10, // <F> ::= <SQRT>
        RULE_F3                 = 11, // <F> ::= <LN>
        RULE_F4                 = 12, // <F> ::= <FACT>
        RULE_FUNC_SIN           = 13, // <FUNC> ::= <F> sin <F>
        RULE_FUNC_TAN           = 14, // <FUNC> ::= <F> tan <F>
        RULE_FUNC_SIN2          = 15, // <FUNC> ::= sin <F>
        RULE_FUNC_TAN2          = 16, // <FUNC> ::= tan <F>
        RULE_SQRT_SQRT          = 17, // <SQRT> ::= sqrt <E>
        RULE_LN_LN              = 18, // <LN> ::= ln <E>
        RULE_FACT_ENTERO_EXCLAM = 19  // <FACT> ::= Entero '!'
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnReduce += new LALRParser.ReduceHandler(ReduceEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
            parser.OnAccept += new LALRParser.AcceptHandler(AcceptEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            parser.Parse(source);

        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        private Object CreateObject(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_EXCLAM :
                //'!'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_ENTERO :
                //Entero
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_LN :
                //ln
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_REAL :
                //Real
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_SIN :
                //sin
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_SQRT :
                //sqrt
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_TAN :
                //tan
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_E :
                //<E>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_F :
                //<F>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACT :
                //<FACT>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC :
                //<FUNC>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LN2 :
                //<LN>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SQRT2 :
                //<SQRT>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_T :
                //<T>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        public static Object CreateObject(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_E_PLUS :
                //<E> ::= <E> '+' <T>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[0].UserObject)+ Convert.ToDouble(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_E_MINUS :
                //<E> ::= <E> '-' <T>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[0].UserObject)-Convert.ToDouble(token.Tokens[2].UserObject;

                case (int)RuleConstants.RULE_E :
                //<E> ::= <T>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[0]);

                case (int)RuleConstants.RULE_T_TIMES :
                //<T> ::= <T> '*' <F>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[0])* Convert.ToDouble(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_T_DIV :
                //<T> ::= <T> '/' <F>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[0].UserObject)/ Convert.ToDouble(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_T :
                //<T> ::= <F>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[0].UserObject);

                case (int)RuleConstants.RULE_F_LPAREN_RPAREN :
                //<F> ::= '(' <E> ')'
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[1].UserObject);

                case (int)RuleConstants.RULE_F_ENTERO :
                //<F> ::= Entero
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[0].UserObject);

                case (int)RuleConstants.RULE_F_REAL :
                //<F> ::= Real
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[0].UserObject);

                case (int)RuleConstants.RULE_F :
                //<F> ::= <FUNC>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[0].UserObject);

                case (int)RuleConstants.RULE_F2 :
                //<F> ::= <SQRT>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[0].UserObject);

                case (int)RuleConstants.RULE_F3 :
                //<F> ::= <LN>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[0].UserObject);

                case (int)RuleConstants.RULE_F4 :
                //<F> ::= <FACT>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[0].UserObject);

                case (int)RuleConstants.RULE_FUNC_SIN :
                    //<FUNC> ::= <F> sin <F>
                    //todo: Create a new object using the stored user objects.
                    return Convert.ToDouble(token.Tokens[0]) * Convert.ToDouble(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_FUNC_TAN :
                //<FUNC> ::= <F> tan <F>
                //todo: Create a new object using the stored user objects.
                return Convert.ToDouble(token.Tokens[0].UserObject) * Convert.ToDouble(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_FUNC_SIN2 :
                //<FUNC> ::= sin <F>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FUNC_TAN2 :
                //<FUNC> ::= tan <F>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SQRT_SQRT :
                //<SQRT> ::= sqrt <E>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LN_LN :
                //<LN> ::= ln <E>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FACT_ENTERO_EXCLAM :
                //<FACT> ::= Entero '!'
                //todo: Create a new object using the stored user objects.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        public string resultado;
        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            //todo: Use your fully reduced args.Token.UserObject
            try {
                resultado = Convert.ToString(args.Token.UserObject)
            } catch(Exception e) {
                resultado = "Error";   
            }
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }


    }
}
