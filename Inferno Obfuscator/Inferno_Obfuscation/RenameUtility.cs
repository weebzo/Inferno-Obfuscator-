using System;
using System.Collections.Generic;
using System.Text;

namespace Inferno_Obfuscation
{
	// Token: 0x0200004E RID: 78
	public sealed class RenameUtility
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600017D RID: 381 RVA: 0x00021282 File Offset: 0x0001F482
		public Random Random
		{
			get
			{
				return this.random;
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0002128A File Offset: 0x0001F48A
		public RenameUtility()
		{
			this.random = new Random();
			this.used = new HashSet<string>();
			this.index = 32;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x000212B2 File Offset: 0x0001F4B2
		public RenameUtility(int seed)
		{
			this.random = new Random(seed);
			this.used = new HashSet<string>();
			this.index = 32;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000212DB File Offset: 0x0001F4DB
		public RenameUtility(int seed, IEnumerable<string> exclude)
		{
			this.random = new Random(seed);
			this.used = new HashSet<string>(exclude);
			this.index = 32;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00021305 File Offset: 0x0001F505
		public string GetBase64Encode(string from)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0002130D File Offset: 0x0001F50D
		public string GetMD5Hash(string from)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00021318 File Offset: 0x0001F518
		public string GetObfuscated(bool allowSame)
		{
			return "痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵" + this.GetRandomString(false, 128);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00021340 File Offset: 0x0001F540
		public string GetRandomString(bool allowSame)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < this.random.Next(64) + 1; i++)
			{
				sb.Append("qwertyuiopasdfghjklzxcvbnm痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵QWERTYUIOPASDFGHJKLZXCVBNM"[this.random.Next("qwertyuiopasdfghjklzxcvbnm痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵QWERTYUIOPASDFGHJKLZXCVBNM".Length)]);
			}
			bool flag = !allowSame && this.used.Contains(sb.ToString());
			string result;
			if (flag)
			{
				result = this.GetRandomString(false);
			}
			else
			{
				result = sb.ToString();
			}
			return result;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000213CC File Offset: 0x0001F5CC
		public string GetRandomString(bool allowSame, int length)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < length; i++)
			{
				sb.Append("qwertyuiopasdfghjklzxcvbnm痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵QWERTYUIOPASDFGHJKLZXCVBNM"[this.random.Next("qwertyuiopasdfghjklzxcvbnm痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵QWERTYUIOPASDFGHJKLZXCVBNM".Length)]);
			}
			bool flag = !allowSame && this.used.Contains(sb.ToString());
			string result;
			if (flag)
			{
				result = this.GetRandomString(false);
			}
			else
			{
				result = sb.ToString();
			}
			return result;
		}

		// Token: 0x040000A8 RID: 168
		private Random random;

		// Token: 0x040000A9 RID: 169
		private HashSet<string> used;

		// Token: 0x040000AA RID: 170
		private int index;

		// Token: 0x040000AB RID: 171
		private const string set = "qwertyuiopasdfghjklzxcvbnm痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵QWERTYUIOPASDFGHJKLZXCVBNM";
	}
}
