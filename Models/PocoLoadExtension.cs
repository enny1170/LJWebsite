using System;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace LJWebsite.Models
{
    public static class PocoLoadingExtensions
    {
        public static TRelated Load<TRelated>(
            this Action<object, string> loader, 
            object entity, 
            ref TRelated navigationField, 
            [CallerMemberName] string navigationName = null) 
            where TRelated : class
            {
                loader?.Invoke(entity, navigationName);
                return navigationField;
            }
    }
}