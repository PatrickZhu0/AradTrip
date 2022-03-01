using System;
using UnityEngine;
using UnityEngine.Profiling;

// Token: 0x02000135 RID: 309
public class HUDInfoViewer : MonoSingleton<HUDInfoViewer>
{
	// Token: 0x060008EB RID: 2283 RVA: 0x0002F3CD File Offset: 0x0002D7CD
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060008EC RID: 2284 RVA: 0x0002F3DB File Offset: 0x0002D7DB
	private void Update()
	{
		this.UpdateUsed();
		this.UpdateFPS();
	}

	// Token: 0x060008ED RID: 2285 RVA: 0x0002F3EC File Offset: 0x0002D7EC
	private void UpdateUsed()
	{
		this.cnt++;
		if (this.cnt < 5)
		{
			return;
		}
		this.cnt = 0;
		this.sUserMemory = string.Empty;
		this.MonoUsedM = Profiler.GetMonoUsedSize() / 1048576f;
		this.AllMemory = Profiler.GetTotalAllocatedMemory() / 1048576f;
		this.sUserMemory = this.sUserMemory + "Mono Used:" + this.MonoUsedM.ToString("f2") + "MB\n";
		this.sUserMemory = this.sUserMemory + "Used Heap:" + (Profiler.usedHeapSize / 1048576f).ToString("f2") + "MB\n";
		this.sUserMemory = this.sUserMemory + "Mono Heap:" + (Profiler.GetMonoHeapSize() / 1048576f).ToString("f2") + "MB\n";
		this.sUserMemory = this.sUserMemory + "UnUsedReserved:" + (Profiler.GetTotalUnusedReservedMemory() / 1048576f).ToString("f2") + "MB\n";
		this.sUserMemory = this.sUserMemory + "AllMemory:" + this.AllMemory.ToString("f2") + "MB\n";
		string text = this.sUserMemory;
		this.sUserMemory = string.Concat(new object[]
		{
			text,
			"Pooled Game Objects:",
			Singleton<CGameObjectPool>.instance.GetPooledGameObjectNum(),
			"\n"
		});
	}

	// Token: 0x060008EE RID: 2286 RVA: 0x0002F580 File Offset: 0x0002D980
	private void UpdateFPS()
	{
		this.timeleft -= Time.deltaTime;
		this.accum += Time.timeScale / Time.deltaTime;
		this.frames += 1f;
		if ((double)this.timeleft <= 0.0)
		{
			this.fps = this.accum / this.frames;
			this.FPSAAA = "FPS: " + this.fps.ToString("f2");
			this.timeleft = this.updateInterval;
			this.accum = 0f;
			this.frames = 0f;
		}
	}

	// Token: 0x060008EF RID: 2287 RVA: 0x0002F634 File Offset: 0x0002DA34
	private void OnGUI()
	{
		if (this.OnMemoryGUI)
		{
			GUI.color = new Color(0f, 1f, 0f);
			GUI.Label(new Rect(10f, (float)(Screen.height - 140), 200f, 100f), this.sUserMemory);
			GUI.Label(new Rect(10f, (float)(Screen.height - 40), 100f, 30f), this.FPSAAA);
		}
	}

	// Token: 0x040006D7 RID: 1751
	private string sUserMemory;

	// Token: 0x040006D8 RID: 1752
	private string s;

	// Token: 0x040006D9 RID: 1753
	public bool OnMemoryGUI = true;

	// Token: 0x040006DA RID: 1754
	private float MonoUsedM;

	// Token: 0x040006DB RID: 1755
	private float AllMemory;

	// Token: 0x040006DC RID: 1756
	[Range(0f, 100f)]
	public int MaxMonoUsedM = 50;

	// Token: 0x040006DD RID: 1757
	[Range(0f, 400f)]
	public int MaxAllMemory = 200;

	// Token: 0x040006DE RID: 1758
	private int cnt;

	// Token: 0x040006DF RID: 1759
	private float updateInterval = 0.5f;

	// Token: 0x040006E0 RID: 1760
	private float accum;

	// Token: 0x040006E1 RID: 1761
	private float frames;

	// Token: 0x040006E2 RID: 1762
	private float timeleft;

	// Token: 0x040006E3 RID: 1763
	private float fps;

	// Token: 0x040006E4 RID: 1764
	private string FPSAAA;

	// Token: 0x040006E5 RID: 1765
	[Range(0f, 150f)]
	public int MaxFPS;
}
