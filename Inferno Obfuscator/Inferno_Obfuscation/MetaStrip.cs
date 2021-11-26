using System;
using dnlib.DotNet;

namespace Inferno_Obfuscation
{
	// Token: 0x0200003E RID: 62
	internal class MetaStrip
	{
		// Token: 0x0600013C RID: 316 RVA: 0x0001A314 File Offset: 0x00018514
		public static void Execute(ModuleDefMD module)
		{
			foreach (CustomAttribute attr in module.Assembly.CustomAttributes)
			{
				bool flag = Rename2.CanRename(attr);
				if (flag)
				{
					module.Assembly.CustomAttributes.Remove(attr);
				}
			}
			module.Mvid = null;
			module.Name = null;
			foreach (TypeDef type in module.Types)
			{
				foreach (CustomAttribute attr2 in type.CustomAttributes)
				{
					bool flag2 = Rename2.CanRename(attr2);
					if (flag2)
					{
						type.CustomAttributes.Remove(attr2);
					}
				}
				foreach (MethodDef i in type.Methods)
				{
					foreach (CustomAttribute attr3 in i.CustomAttributes)
					{
						bool flag3 = Rename2.CanRename(attr3);
						if (flag3)
						{
							i.CustomAttributes.Remove(attr3);
						}
					}
				}
				foreach (PropertyDef p in type.Properties)
				{
					foreach (CustomAttribute attr4 in p.CustomAttributes)
					{
						bool flag4 = Rename2.CanRename(attr4);
						if (flag4)
						{
							p.CustomAttributes.Remove(attr4);
						}
					}
				}
				foreach (FieldDef field in type.Fields)
				{
					foreach (CustomAttribute attr5 in field.CustomAttributes)
					{
						bool flag5 = Rename2.CanRename(attr5);
						if (flag5)
						{
							field.CustomAttributes.Remove(attr5);
						}
					}
				}
				foreach (EventDef e in type.Events)
				{
					foreach (CustomAttribute attr6 in e.CustomAttributes)
					{
						bool flag6 = Rename2.CanRename(attr6);
						if (flag6)
						{
							e.CustomAttributes.Remove(attr6);
						}
					}
				}
			}
		}
	}
}
