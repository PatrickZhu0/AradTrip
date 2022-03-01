using System;

// Token: 0x020001EB RID: 491
public class Singleton<T> where T : class, new()
{
	// Token: 0x06000F7F RID: 3967 RVA: 0x0000DD27 File Offset: 0x0000C127
	protected Singleton()
	{
	}

	// Token: 0x06000F80 RID: 3968 RVA: 0x0000DD2F File Offset: 0x0000C12F
	public static void CreateInstance(bool bInit = true)
	{
		if (Singleton<T>.s_instance == null)
		{
			Singleton<T>.s_instance = Activator.CreateInstance<T>();
			if (bInit)
			{
				(Singleton<T>.s_instance as Singleton<T>).Init();
			}
		}
	}

	// Token: 0x06000F81 RID: 3969 RVA: 0x0000DD64 File Offset: 0x0000C164
	public static void DestroyInstance()
	{
		if (Singleton<T>.s_instance != null)
		{
			(Singleton<T>.s_instance as Singleton<T>).UnInit();
			Singleton<T>.s_instance = (T)((object)null);
		}
	}

	// Token: 0x06000F82 RID: 3970 RVA: 0x0000DD94 File Offset: 0x0000C194
	public static T GetInstance()
	{
		if (Singleton<T>.s_instance == null)
		{
			Singleton<T>.CreateInstance(true);
		}
		return Singleton<T>.s_instance;
	}

	// Token: 0x06000F83 RID: 3971 RVA: 0x0000DDB0 File Offset: 0x0000C1B0
	public static bool HasInstance()
	{
		return Singleton<T>.s_instance != null;
	}

	// Token: 0x06000F84 RID: 3972 RVA: 0x0000DDC2 File Offset: 0x0000C1C2
	public virtual void Init()
	{
	}

	// Token: 0x06000F85 RID: 3973 RVA: 0x0000DDC4 File Offset: 0x0000C1C4
	public virtual void UnInit()
	{
	}

	// Token: 0x06000F86 RID: 3974 RVA: 0x0000DDC6 File Offset: 0x0000C1C6
	public static void Initialize()
	{
		if (Singleton<T>.s_instance == null)
		{
			Singleton<T>.CreateInstance(true);
		}
	}

	// Token: 0x170001F3 RID: 499
	// (get) Token: 0x06000F87 RID: 3975 RVA: 0x0000DDDD File Offset: 0x0000C1DD
	public static T instance
	{
		get
		{
			if (Singleton<T>.s_instance == null)
			{
				Singleton<T>.CreateInstance(true);
			}
			return Singleton<T>.s_instance;
		}
	}

	// Token: 0x04000AC1 RID: 2753
	private static T s_instance;
}
