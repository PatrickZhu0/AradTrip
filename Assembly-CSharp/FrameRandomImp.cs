using System;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;

// Token: 0x02000228 RID: 552
public class FrameRandomImp
{
	// Token: 0x0600127A RID: 4730 RVA: 0x00063BC2 File Offset: 0x00061FC2
	private static void RecordStackTrace()
	{
	}

	// Token: 0x0600127B RID: 4731 RVA: 0x00063BC4 File Offset: 0x00061FC4
	private static bool GetPathLastName(string fullPath, char split, ref string outstring)
	{
		int num = fullPath.LastIndexOf(split);
		if (num >= 0)
		{
			num++;
			int num2 = fullPath.Length - num;
			if (num2 > 0)
			{
				outstring = fullPath.Substring(num, num2);
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600127C RID: 4732 RVA: 0x00063C04 File Offset: 0x00062004
	private static string GetFileNameWithNoPath(string fullpath)
	{
		if (string.IsNullOrEmpty(fullpath))
		{
			return string.Empty;
		}
		string result = fullpath;
		if (FrameRandomImp.GetPathLastName(fullpath, '/', ref result))
		{
			return result;
		}
		if (FrameRandomImp.GetPathLastName(fullpath, '\\', ref result))
		{
			return result;
		}
		return result;
	}

	// Token: 0x0600127D RID: 4733 RVA: 0x00063C48 File Offset: 0x00062048
	public static void PrintStackTrace(RecordServer r, int stCount)
	{
		StackTrace stackTrace = new StackTrace(true);
		int num = Math.Min(stCount, stackTrace.FrameCount);
		for (int i = 0; i < num; i++)
		{
			StackFrame frame = stackTrace.GetFrame(i);
			string fileNameWithNoPath = FrameRandomImp.GetFileNameWithNoPath(frame.GetFileName());
			MethodBase method = frame.GetMethod();
			string text = string.Format("{0}:{1} {2} {3}", new object[]
			{
				method.DeclaringType.Name,
				method.Name,
				fileNameWithNoPath,
				frame.GetFileLineNumber()
			});
		}
	}

	// Token: 0x0600127E RID: 4734 RVA: 0x00063CDF File Offset: 0x000620DF
	public void RandomCallNum(uint count)
	{
		this.callNum += count;
	}

	// Token: 0x0600127F RID: 4735 RVA: 0x00063CF0 File Offset: 0x000620F0
	public ushort Random(uint nMax)
	{
		if (nMax == 0U)
		{
			return 0;
		}
		this.callNum += 1U;
		this.nSeed = this.nSeed * 1194211693U + 12345U;
		return (ushort)((this.nSeed >> 16) % nMax);
	}

	// Token: 0x06001280 RID: 4736 RVA: 0x00063D39 File Offset: 0x00062139
	public ushort Range100()
	{
		FrameRandomImp.RecordStackTrace();
		return this.Random((uint)GlobalLogic.VALUE_100) + 1;
	}

	// Token: 0x06001281 RID: 4737 RVA: 0x00063D4E File Offset: 0x0006214E
	public ushort Range1000()
	{
		FrameRandomImp.RecordStackTrace();
		return this.Random((uint)GlobalLogic.VALUE_1000) + 1;
	}

	// Token: 0x06001282 RID: 4738 RVA: 0x00063D63 File Offset: 0x00062163
	public int InRange(int low, int high)
	{
		FrameRandomImp.RecordStackTrace();
		return (int)this.Random((uint)(high - low)) + low;
	}

	// Token: 0x06001283 RID: 4739 RVA: 0x00063D75 File Offset: 0x00062175
	public int InRange(long low, long high)
	{
		FrameRandomImp.RecordStackTrace();
		return (int)((long)this.Random((uint)(high - low)) + low);
	}

	// Token: 0x06001284 RID: 4740 RVA: 0x00063D8A File Offset: 0x0006218A
	public uint GetSeed()
	{
		return this.nSeed;
	}

	// Token: 0x06001285 RID: 4741 RVA: 0x00063D92 File Offset: 0x00062192
	public void ResetSeed(uint seed)
	{
		this.nSeed = seed;
		this.callNum = 0U;
	}

	// Token: 0x04000C3A RID: 3130
	private const uint addValue = 12345U;

	// Token: 0x04000C3B RID: 3131
	public uint callNum;

	// Token: 0x04000C3C RID: 3132
	public uint callFrame;

	// Token: 0x04000C3D RID: 3133
	private const uint maxShort = 65536U;

	// Token: 0x04000C3E RID: 3134
	private const uint multiper = 1194211693U;

	// Token: 0x04000C3F RID: 3135
	public RecordServer mRecordServer;

	// Token: 0x04000C40 RID: 3136
	private uint nSeed = (uint)UnityEngine.Random.Range(32767, int.MaxValue);
}
