using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Parser;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020045FB RID: 17915
public class TextPic : Text, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060192ED RID: 103149 RVA: 0x007F6AE0 File Offset: 0x007F4EE0
	public override void SetVerticesDirty()
	{
		base.SetVerticesDirty();
		this.UpdateQuadImage();
	}

	// Token: 0x060192EE RID: 103150 RVA: 0x007F6AF0 File Offset: 0x007F4EF0
	protected void UpdateQuadImage()
	{
		this.m_OutputText = this.Parse();
		this.m_ImagesVertexIndex.Clear();
		IEnumerator enumerator = TextPic.s_Regex.Matches(this.m_OutputText).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Match match = (Match)obj;
				int num = match.Index + match.Length - 1;
				int item = num * 4 + 3;
				this.m_ImagesVertexIndex.Add(item);
				this.m_ImagesPool.RemoveAll((Image image) => image == null);
				if (this.m_ImagesPool.Count == 0)
				{
					base.GetComponentsInChildren<Image>(this.m_ImagesPool);
				}
				if (this.m_ImagesVertexIndex.Count > this.m_ImagesPool.Count)
				{
					GameObject gameObject = DefaultControls.CreateImage(default(DefaultControls.Resources));
					gameObject.layer = base.gameObject.layer;
					RectTransform rectTransform = gameObject.transform as RectTransform;
					if (rectTransform)
					{
						rectTransform.SetParent(base.rectTransform);
						rectTransform.localPosition = Vector3.zero;
						rectTransform.localRotation = Quaternion.identity;
						rectTransform.localScale = Vector3.one;
						rectTransform.pivot = Vector2.zero;
					}
					this.m_ImagesPool.Add(gameObject.GetComponent<Image>());
				}
				string value = match.Groups[1].Value;
				float num2 = float.Parse(match.Groups[2].Value);
				Image image2 = this.m_ImagesPool[this.m_ImagesVertexIndex.Count - 1];
				if (image2.sprite == null || image2.sprite.name != value)
				{
					ETCImageLoader.LoadSprite(ref image2, value, true);
					image2.rectTransform.pivot = Vector2.zero;
				}
				image2.rectTransform.sizeDelta = new Vector2(num2, num2);
				image2.enabled = true;
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		for (int i = this.m_ImagesVertexIndex.Count; i < this.m_ImagesPool.Count; i++)
		{
			if (this.m_ImagesPool[i])
			{
				this.m_ImagesPool[i].enabled = false;
			}
		}
	}

	// Token: 0x060192EF RID: 103151 RVA: 0x007F6D88 File Offset: 0x007F5188
	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		string text = this.m_Text;
		this.m_Text = this.m_OutputText;
		base.OnPopulateMesh(toFill);
		this.m_Text = text;
		UIVertex uivertex = default(UIVertex);
		for (int i = 0; i < this.m_ImagesVertexIndex.Count; i++)
		{
			int num = this.m_ImagesVertexIndex[i];
			RectTransform rectTransform = this.m_ImagesPool[i].rectTransform;
			Vector2 sizeDelta = rectTransform.sizeDelta;
			if (num < toFill.currentVertCount)
			{
				toFill.PopulateUIVertex(ref uivertex, num);
				rectTransform.anchoredPosition = new Vector2(uivertex.position.x - rectTransform.sizeDelta.x * rectTransform.pivot.x, uivertex.position.y - rectTransform.sizeDelta.y * rectTransform.pivot.y);
				toFill.PopulateUIVertex(ref uivertex, num - 3);
				Vector3 position = uivertex.position;
				int j = num;
				int num2 = num - 3;
				while (j > num2)
				{
					toFill.PopulateUIVertex(ref uivertex, num);
					uivertex.position = position;
					toFill.SetUIVertex(uivertex, j);
					j--;
				}
			}
		}
		if (this.m_ImagesVertexIndex.Count != 0)
		{
			this.m_ImagesVertexIndex.Clear();
		}
		foreach (TextPic.HrefInfo hrefInfo in this.m_HrefInfos)
		{
			hrefInfo.boxes.Clear();
			if (hrefInfo.startIndex < toFill.currentVertCount)
			{
				toFill.PopulateUIVertex(ref uivertex, hrefInfo.startIndex);
				Vector3 position2 = uivertex.position;
				Bounds bounds;
				bounds..ctor(position2, Vector3.zero);
				int k = hrefInfo.startIndex;
				int endIndex = hrefInfo.endIndex;
				while (k < endIndex)
				{
					if (k >= toFill.currentVertCount)
					{
						break;
					}
					toFill.PopulateUIVertex(ref uivertex, k);
					position2 = uivertex.position;
					if (position2.x < bounds.min.x)
					{
						hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
						bounds..ctor(position2, Vector3.zero);
					}
					else
					{
						bounds.Encapsulate(position2);
					}
					k++;
				}
				hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
			}
		}
	}

	// Token: 0x170020AF RID: 8367
	// (get) Token: 0x060192F0 RID: 103152 RVA: 0x007F705C File Offset: 0x007F545C
	// (set) Token: 0x060192F1 RID: 103153 RVA: 0x007F7064 File Offset: 0x007F5464
	public TextPic.HrefClickEvent onHrefClick
	{
		get
		{
			return this.m_OnHrefClick;
		}
		set
		{
			this.m_OnHrefClick = value;
		}
	}

	// Token: 0x060192F2 RID: 103154 RVA: 0x007F7070 File Offset: 0x007F5470
	public void OnPointerClick(PointerEventData eventData)
	{
		Vector2 vector;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, eventData.position, eventData.pressEventCamera, ref vector);
		foreach (TextPic.HrefInfo hrefInfo in this.m_HrefInfos)
		{
			List<Rect> boxes = hrefInfo.boxes;
			for (int i = 0; i < boxes.Count; i++)
			{
				if (boxes[i].Contains(vector))
				{
					this.m_OnHrefClick.Invoke(hrefInfo.key + "|" + hrefInfo.value);
					return;
				}
			}
		}
	}

	// Token: 0x060192F3 RID: 103155 RVA: 0x007F7140 File Offset: 0x007F5540
	private string Parse()
	{
		TextPic.s_TextBuilder.Length = 0;
		this.m_HrefInfos.Clear();
		int num = 0;
		IEnumerator enumerator = TextPic.s_HrefRegex.Matches(this.text).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Match match = (Match)obj;
				TextPic.s_TextBuilder.Append(this.text.Substring(num, match.Index - num));
				ParserReturn parserReturn = this.OnParse(match.Groups[1].Value, match.Groups[2].Value);
				if (this.bNeedParserColor)
				{
					TextPic.s_TextBuilder.Append(string.Format("<color={0}>", parserReturn.color));
				}
				Group group = match.Groups[1];
				TextPic.HrefInfo item = new TextPic.HrefInfo
				{
					startIndex = TextPic.s_TextBuilder.Length * 4,
					endIndex = (TextPic.s_TextBuilder.Length + parserReturn.content.Length - 1) * 4 + 3,
					key = group.Value,
					value = parserReturn.iId.ToString()
				};
				this.m_HrefInfos.Add(item);
				TextPic.s_TextBuilder.Append(parserReturn.content);
				if (this.bNeedParserColor)
				{
					TextPic.s_TextBuilder.Append("</color>");
				}
				num = match.Index + match.Length;
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		TextPic.s_TextBuilder.Append(this.text.Substring(num, this.text.Length - num));
		return TextPic.s_TextBuilder.ToString();
	}

	// Token: 0x060192F4 RID: 103156 RVA: 0x007F732C File Offset: 0x007F572C
	protected ParserReturn OnParse(string key, string value)
	{
		ParserReturn result;
		result.color = "0xFFFFFF";
		result.content = string.Empty;
		result.iId = 0U;
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string text = string.Empty;
		if (key.Length > 0)
		{
			text = key.Substring(0, 1);
			text = text.ToUpper();
			if (key.Length > 1)
			{
				text += key.Substring(1, key.Length - 1);
			}
		}
		if (text.Length <= 0)
		{
			return result;
		}
		string typeName = "Parser." + text + "Parser";
		object obj = executingAssembly.CreateInstance(typeName);
		if (obj != null)
		{
			IParser parser = obj as IParser;
			if (parser != null)
			{
				return parser.OnParse(value);
			}
		}
		return result;
	}

	// Token: 0x040120A0 RID: 73888
	private readonly List<Image> m_ImagesPool = new List<Image>();

	// Token: 0x040120A1 RID: 73889
	private readonly List<int> m_ImagesVertexIndex = new List<int>();

	// Token: 0x040120A2 RID: 73890
	private static readonly Regex s_Regex = new Regex("<quad name=(.+?) size=(\\d*\\.?\\d+%?) width=(\\d*\\.?\\d+%?) />", RegexOptions.Singleline);

	// Token: 0x040120A3 RID: 73891
	private string m_OutputText;

	// Token: 0x040120A4 RID: 73892
	private readonly List<TextPic.HrefInfo> m_HrefInfos = new List<TextPic.HrefInfo>();

	// Token: 0x040120A5 RID: 73893
	private static readonly StringBuilder s_TextBuilder = new StringBuilder();

	// Token: 0x040120A6 RID: 73894
	private static readonly Regex s_HrefRegex = new Regex("<a href=([^>\\n\\s]+)>(.*?)(</a>)", RegexOptions.Singleline);

	// Token: 0x040120A7 RID: 73895
	[SerializeField]
	private TextPic.HrefClickEvent m_OnHrefClick = new TextPic.HrefClickEvent();

	// Token: 0x040120A8 RID: 73896
	public bool bNeedParserColor;

	// Token: 0x020045FC RID: 17916
	[Serializable]
	public class HrefClickEvent : UnityEvent<string>
	{
	}

	// Token: 0x020045FD RID: 17917
	private class HrefInfo
	{
		// Token: 0x040120AA RID: 73898
		public int startIndex;

		// Token: 0x040120AB RID: 73899
		public int endIndex;

		// Token: 0x040120AC RID: 73900
		public string key;

		// Token: 0x040120AD RID: 73901
		public string value;

		// Token: 0x040120AE RID: 73902
		public readonly List<Rect> boxes = new List<Rect>();
	}
}
