namespace QuickGraph.Graphviz.Dot
{
    using System;
    using System.Text.RegularExpressions;
#if CTR
    using System.Diagnostics.Contracts;
#endif

    public sealed class GraphvizRecordEscaper
    {
        private Regex escapeRegExp = new Regex("(?<Eol>\\n)|(?<Common>\\[|\\]|\\||<|>|\"| )", RegexOptions.ExplicitCapture | RegexOptions.Multiline);

        public string Escape(string text)
        {
#if CTR
            Contract.Requires(text != null);
#endif
            return this.escapeRegExp.Replace(text, new System.Text.RegularExpressions.MatchEvaluator(this.MatchEvaluator));
        }

        public string MatchEvaluator(Match m)
        {
            if (m.Groups["Common"] != null)
            {
                return string.Format(@"\{0}", m.Value);
            }
            return @"\n";
        }
    }
}

