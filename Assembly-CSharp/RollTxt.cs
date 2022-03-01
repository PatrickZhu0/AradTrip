using System;
using UnityEngine;

// Token: 0x02001435 RID: 5173
public class RollTxt : MonoBehaviour
{
	// Token: 0x0600C8DF RID: 51423 RVA: 0x0030D5E3 File Offset: 0x0030B9E3
	private void Start()
	{
		this.txtLength = this.txt.Length;
		this.showTxt = this.txt.Substring(0, this.showLength);
		this.indexMax = this.txtLength - this.showLength + 1;
	}

	// Token: 0x0600C8E0 RID: 51424 RVA: 0x0030D623 File Offset: 0x0030BA23
	private void Update()
	{
		this.GetShowTxt();
	}

	// Token: 0x0600C8E1 RID: 51425 RVA: 0x0030D62B File Offset: 0x0030BA2B
	private void OnGUI()
	{
		GUI.Box(new Rect(200f, 200f, 150f, 20f), this.showTxt);
	}

	// Token: 0x0600C8E2 RID: 51426 RVA: 0x0030D654 File Offset: 0x0030BA54
	private void GetShowTxt()
	{
		if (this.showLength >= this.txtLength)
		{
			this.showTxt = this.txt;
		}
		else if (this.showLength < this.txtLength)
		{
			int startIndex = (int)(Mathf.PingPong(Time.time * this.rollSpeed, 1f) * (float)this.indexMax);
			this.showTxt = this.txt.Substring(startIndex, this.showLength);
		}
	}

	// Token: 0x040073D6 RID: 29654
	private string txt = "1234567werweerty74874651rtyrghdfgdgdfg891234wrew56789";

	// Token: 0x040073D7 RID: 29655
	public string showTxt;

	// Token: 0x040073D8 RID: 29656
	public int showLength = 8;

	// Token: 0x040073D9 RID: 29657
	public int txtLength;

	// Token: 0x040073DA RID: 29658
	public float rollSpeed = 0.1f;

	// Token: 0x040073DB RID: 29659
	private int indexMax;
}
