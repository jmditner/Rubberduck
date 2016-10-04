﻿using System.Collections;
using System.Collections.Generic;

namespace Rubberduck.VBEditor.DisposableWrappers.Office.Core
{
    public class CommandBars : SafeComWrapper<Microsoft.Office.Core.CommandBars>, IEnumerable<CommandBar>
    {
        public CommandBars(Microsoft.Office.Core.CommandBars comObject) 
            : base(comObject)
        {
        }

        public CommandBar Add(string name)
        {
            return new CommandBar(InvokeResult(() => ComObject.Add(name, Temporary:true)));
        }

        public CommandBar Add(string name, int position)
        {
            return new CommandBar(InvokeResult(() => ComObject.Add(name, position, Temporary: true)));
        }

        IEnumerator<CommandBar> IEnumerable<CommandBar>.GetEnumerator()
        {
            return new ComWrapperEnumerator<CommandBar>(this);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<CommandBar>)this).GetEnumerator();
        }

        public int Count { get { return InvokeResult(() => ComObject.Count); } }

        public CommandBar this[object index]
        {
            get { return new CommandBar(InvokeResult(() => ComObject[index])); }
        }
    }
}