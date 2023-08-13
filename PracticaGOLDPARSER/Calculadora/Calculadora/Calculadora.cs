
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

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
        SYMBOL_LPAREN     =  4, // '('
        SYMBOL_RPAREN     =  5, // ')'
        SYMBOL_TIMES      =  6, // '*'
        SYMBOL_DIV        =  7, // '/'
        SYMBOL_PLUS       =  8, // '+'
        SYMBOL_ENTERO     =  9, // Entero
        SYMBOL_REAL       = 10, // Real
        SYMBOL_E          = 11, // <E>
        SYMBOL_F          = 12, // <F>
        SYMBOL_T          = 13  // <T>
    };

    enum RuleConstants : int
    {
        RULE_E_PLUS          =  0, // <E> ::= <E> '+' <T>
        RULE_E_MINUS         =  1, // <E> ::= <E> '-' <T>
        RULE_E               =  2, // <E> ::= <T>
        RULE_T_TIMES         =  3, // <T> ::= <T> '*' <F>
        RULE_T_DIV           =  4, // <T> ::= <T> '/' <F>
        RULE_T               =  5, // <T> ::= <F>
        RULE_F_LPAREN_RPAREN =  6, // <F> ::= '(' <E> ')'
        RULE_F_ENTERO        =  7, // <F> ::= Entero
        RULE_F_REAL          =  8  // <F> ::= Real
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
                    //MessageBox.Show("lei" + token.Text);
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                    //'('
                    //todo: Create a new object that corresponds to the symbol
                    //MessageBox.Show("lei" + token.Text);
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                    //')'
                    //todo: Create a new object that corresponds to the symbol
                    //MessageBox.Show("lei " + token.Text);
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TIMES :
                    //'*'
                    //todo: Create a new object that corresponds to the symbol
                    //MessageBox.Show("lei "  + token.Text);
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DIV :
                    //'/'
                    //todo: Create a new object that corresponds to the symbol
                    //MessageBox.Show("lei " + token.Text);
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PLUS :
                    //'+'
                    //todo: Create a new object that corresponds to the symbol
                    //MessageBox.Show("lei " + token.Text);
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_ENTERO :
                    //Entero
                    //todo: Create a new object that corresponds to the symbol
                    //MessageBox.Show("lei " + token.Text);
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_REAL :
                    //Real
                    //todo: Create a new object that corresponds to the symbol
                    //MessageBox.Show("lei " + token.Text);
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_E :
                //<E>
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_F :
                //<F>
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

                case (int)SymbolConstants.SYMBOL_T :
                //<T>
                //todo: Create a new object that corresponds to the symbol
                return token.Text;

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
                case (int)RuleConstants.RULE_E_PLUS:
                    //<E> ::= <E> '+' <T>
                    //todo: Create a new object using the stored user objects.
                    return Convert.ToInt32(token.Tokens[0].UserObject) + Convert.ToInt32(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_E_MINUS:
                    //<E> ::= <E> '-' <T>
                    //todo: Create a new object using the stored user objects.
                    return Convert.ToInt32(token.Tokens[0].UserObject) - Convert.ToInt32(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_E:
                    //<E> ::= <T>
                    //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_T_TIMES:
                    //<T> ::= <T> '*' <F>
                    //todo: Create a new object using the stored user objects.
                    return Convert.ToInt32(token.Tokens[0].UserObject) * Convert.ToInt32(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_T_DIV:
                    //<T> ::= <T> '/' <F>
                    //todo: Create a new object using the stored user objects.
                    return Convert.ToInt32(token.Tokens[0].UserObject) / Convert.ToInt32(token.Tokens[2].UserObject);

                case (int)RuleConstants.RULE_T:
                    //<T> ::= <F>
                    //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_F_LPAREN_RPAREN:
                    //<F> ::= '(' <E> ')'
                    //todo: Create a new object using the stored user objects.
                    return token.Tokens[1].UserObject;

                case (int)RuleConstants.RULE_F_ENTERO:
                    //<F> ::= Entero
                    //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject;

                case (int)RuleConstants.RULE_F_REAL:
                    //<F> ::= Real
                    //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject;


            }
            throw new RuleException("Unknown rule");
        }

        public String resultado;
        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            try 
            {
                resultado = Convert.ToString(args.Token.UserObject);
            }
            catch (Exception e) { resultado = "Error"; }
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
            resultado = "Error Lexico " + args.Token.ToString();
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
            resultado = "Error Sintactico" + args.UnexpectedToken.ToString();
        }


    }
}
