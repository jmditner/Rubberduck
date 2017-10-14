using System;
using Rubberduck.VBEditor.Events;
using Rubberduck.VBEditor.SafeComWrappers.VB.Enums;

namespace Rubberduck.VBEditor.SafeComWrappers.VB.Abstract
{
    public interface IVBComponents : ISafeComWrapper, IComCollection<IVBComponent>, IEquatable<IVBComponents>
    {
        new IVBComponent this[object index] { get; }

        IVBE VBE { get; }
        IVBProject Parent { get; }
        void Remove(IVBComponent item);
        IVBComponent Add(ComponentType type);
        IVBComponent Import(string path);
        IVBComponent AddCustom(string progId);
        IVBComponent AddMTDesigner(int index = 0);
        void ImportSourceFile(string path);

        /// <summary>
        /// Safely removes the specified VbComponent from the collection.
        /// </summary>
        /// <remarks>
        /// UserForms, Class modules, and Standard modules are completely removed from the project.
        /// Since Document type components can't be removed through the VBE, all code in its CodeModule are deleted instead.
        /// </remarks>
        void RemoveSafely(IVBComponent component);
    }
}