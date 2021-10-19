using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

public static class CustomHelpers
{
    public static string TelLink(string Number)
    {
        string phoneLink = Regex.Replace(Number, @"[^\d]", string.Empty);
        phoneLink = phoneLink.Length == 10 ? "+1-" + Regex.Replace(phoneLink, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3") : Number;
        phoneLink = "tel:" + phoneLink;
        return phoneLink;
    }
}
