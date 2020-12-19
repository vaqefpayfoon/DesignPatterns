namespace Builder
{
    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootname)
        {
            this.rootName = rootname;
            root.Name = rootName;
        }
        public void AddChild(string childName, string childText)
        {
            HtmlElement e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }
        public override string ToString()
        {
            return root.ToString();
        }
    }
}