﻿using cain_jawbone_domains;

namespace cain_jawbone_resources.Results
{
    public class PageReadResult : AbstractCommandResult
    {
        public PageReadResult() : base() { }
        public PageReadResult(string message) : base(message) { }
        public PageReadResult(Page page) : base(page, true) { }
    }
}