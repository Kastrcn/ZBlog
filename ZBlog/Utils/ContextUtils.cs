namespace ZBlog.Utils
{
    public static class ContextUtils
    {
        public static string SplitTags(this string html)
        {
            return html.Length < 140 ? html : html.Substring(0,140);
        }
    }
}