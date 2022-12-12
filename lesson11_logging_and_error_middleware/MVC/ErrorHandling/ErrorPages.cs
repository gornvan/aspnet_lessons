namespace lesson11_serilog.ErrorHandling
{
    public static class ErrorPages
    {
        public const string InternalErrorPage = @"
                <html> <body> 
                Internal error happened. Please go to the previous page.
                <html/> <body/>
            ";


        public const string NotFoundPage = @"
                <html> <body> 
                <strong>The page You have requested is not available right now. :( <strong/>
                <html/> <body/>
            ";

        public const string BadRequestPageTemplate = @"
                <html> <body> 
                <strong>Badly formed request:<strong/>
                {Message}
                <html/> <body/>
            ";

        public const string FatalErrorPage = @"
                <html> <body> 
                The server is currently unavailable. Please contact the administrator.
                <html/> <body/>
            ";
    }
}
