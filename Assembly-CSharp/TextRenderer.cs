using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;

// Token: 0x02000D33 RID: 3379
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TextRenderer : MonoBehaviour
{
	// Token: 0x060089E9 RID: 35305 RVA: 0x001914DC File Offset: 0x0018F8DC
	public void Init()
	{
		this.verticesNumPerChar = ((!this.outLine) ? 4 : 36);
		this.indicesNumPerChar = ((!this.outLine) ? 6 : 54);
		this.m_Mesh = new Mesh();
		this.m_Vertices = new List<Vector3>(TextRenderer.m_DefaultCapacity * this.verticesNumPerChar);
		this.m_UVs = new List<Vector2>(TextRenderer.m_DefaultCapacity * this.verticesNumPerChar);
		this.m_Triangles = new List<int>(TextRenderer.m_DefaultCapacity * this.indicesNumPerChar);
		this.m_Colors = new List<Color>(TextRenderer.m_DefaultCapacity * this.verticesNumPerChar);
		this.m_Texts = new List<MyText>(TextRenderer.m_DefaultCapacity);
		this.m_OriginVertices = new List<Vector3>(TextRenderer.m_DefaultCapacity * this.verticesNumPerChar);
		this.m_MeshFilter = base.GetComponent<MeshFilter>();
		this.m_MeshRenderer = base.GetComponent<MeshRenderer>();
		this.m_TextGenerator = new TextGenerator();
		this.m_MeshFilter.mesh = this.m_Mesh;
		this.m_MeshRenderer.material = this.fontMaterial;
		this.m_MeshRenderer.material.mainTexture = this.font.material.mainTexture;
		this.m_CurrentNumCount = 0;
		this.m_TextGenerationSettings.font = this.font;
		this.m_TextGenerationSettings.fontSize = this.fontSize;
		RectTransform component = base.gameObject.GetComponent<RectTransform>();
		Vector2 size = component.rect.size;
		this.m_TextGenerationSettings.generationExtents = size;
		if (this.font.dynamic)
		{
			this.m_TextGenerationSettings.scaleFactor = Singleton<ClientSystemManager>.instance.Layer3DRoot.GetComponent<Canvas>().scaleFactor;
		}
		else
		{
			this.m_TextGenerationSettings.scaleFactor = 1f;
		}
		this.m_TextGenerationSettings.textAnchor = this.textAnchor;
		this.m_TextGenerationSettings.alignByGeometry = false;
		this.m_TextGenerationSettings.pivot = component.pivot;
		if (this.type == TextRenderer.TextType.number)
		{
			this.m_EveryNums = new List<int>(10);
			this.GenerateNumberVertices();
		}
		else if (this.type == TextRenderer.TextType.text)
		{
			this.m_StringCache = new List<string>(12);
			Font.textureRebuilt += this.RebuildMesh;
		}
	}

	// Token: 0x060089EA RID: 35306 RVA: 0x0019171D File Offset: 0x0018FB1D
	private void OnDestroy()
	{
		Font.textureRebuilt -= this.RebuildMesh;
	}

	// Token: 0x060089EB RID: 35307 RVA: 0x00191730 File Offset: 0x0018FB30
	public void MoveUpAll(int actorID, int hitEffectType, int animType)
	{
		this.moveUpOffset = 15f;
		if (hitEffectType == 5)
		{
			this.moveUpOffset = 30f;
		}
		for (int i = 0; i < this.m_Texts.Count; i++)
		{
			MyText myText = this.m_Texts[i];
			if (myText.actorID == actorID && myText.hitEffectType == hitEffectType)
			{
				this.m_Texts[i] = new MyText(myText.positionX, myText.positionY + this.moveUpOffset, myText.positionZ, myText.characterCount, myText.passedTime, myText.actorID, myText.hitEffectType, myText.animType, myText.animCurveIndex, myText.charIndex);
			}
		}
	}

	// Token: 0x060089EC RID: 35308 RVA: 0x001917FC File Offset: 0x0018FBFC
	public void AddText(int num, Vec3 position, int actorID, int hitEffectType, int animType, int animCurveIndex)
	{
		num = Mathf.Abs(num);
		int num2 = 0;
		this.m_EveryNums.Clear();
		do
		{
			this.m_EveryNums.Add(num % 10);
			num /= 10;
			num2++;
		}
		while (num != 0);
		float num3 = 0f;
		foreach (int num4 in this.m_EveryNums)
		{
			num3 += this.m_NumberVertexCache[num4].width;
		}
		num3 -= (float)num2;
		float num5 = 0f;
		float num6 = 0f;
		int num7 = 0;
		foreach (int num8 in this.m_EveryNums)
		{
			MyTextVertices myTextVertices = this.m_NumberVertexCache[num8];
			num7++;
			num6 += myTextVertices.width;
			this.m_Vertices.Add(new Vector3(myTextVertices.position0.x - (num6 + num5) / 2f + (float)num7 + num3 / 2f, myTextVertices.position0.y, myTextVertices.position0.z));
			this.m_Vertices.Add(new Vector3(myTextVertices.position1.x - (num6 + num5) / 2f + (float)num7 + num3 / 2f, myTextVertices.position1.y, myTextVertices.position1.z));
			this.m_Vertices.Add(new Vector3(myTextVertices.position2.x - (num6 + num5) / 2f + (float)num7 + num3 / 2f, myTextVertices.position2.y, myTextVertices.position2.z));
			this.m_Vertices.Add(new Vector3(myTextVertices.position3.x - (num6 + num5) / 2f + (float)num7 + num3 / 2f, myTextVertices.position3.y, myTextVertices.position3.z));
			this.m_OriginVertices.Add(new Vector3(myTextVertices.position0.x - (num6 + num5) / 2f + (float)num7 + num3 / 2f, myTextVertices.position0.y, myTextVertices.position0.z));
			this.m_OriginVertices.Add(new Vector3(myTextVertices.position1.x - (num6 + num5) / 2f + (float)num7 + num3 / 2f, myTextVertices.position1.y, myTextVertices.position1.z));
			this.m_OriginVertices.Add(new Vector3(myTextVertices.position2.x - (num6 + num5) / 2f + (float)num7 + num3 / 2f, myTextVertices.position2.y, myTextVertices.position2.z));
			this.m_OriginVertices.Add(new Vector3(myTextVertices.position3.x - (num6 + num5) / 2f + (float)num7 + num3 / 2f, myTextVertices.position3.y, myTextVertices.position3.z));
			this.m_UVs.Add(myTextVertices.uv0);
			this.m_UVs.Add(myTextVertices.uv1);
			this.m_UVs.Add(myTextVertices.uv2);
			this.m_UVs.Add(myTextVertices.uv3);
			this.m_Colors.Add(this.textColor);
			this.m_Colors.Add(this.textColor);
			this.m_Colors.Add(this.textColor);
			this.m_Colors.Add(this.textColor);
			num5 += myTextVertices.width;
		}
		this.m_Texts.Add(new MyText(position.x, position.y, position.z, num2, 0f, actorID, hitEffectType, animType, animCurveIndex, this.m_CurrentNumCount));
		for (int i = this.m_CurrentNumCount; i < this.m_CurrentNumCount + num2; i++)
		{
			int num9 = i * 4;
			int num10 = i * 6;
			this.m_Triangles.Add(num9);
			this.m_Triangles.Add(num9 + 1);
			this.m_Triangles.Add(num9 + 2);
			this.m_Triangles.Add(num9 + 2);
			this.m_Triangles.Add(num9 + 3);
			this.m_Triangles.Add(num9);
		}
		this.m_CurrentNumCount += num2;
	}

	// Token: 0x060089ED RID: 35309 RVA: 0x00191CFC File Offset: 0x001900FC
	public void AddNameText(string content, Vec3 position, int actorID, int hitEffectType, int animType, int animCurveIndex)
	{
		this.m_TextGenerator.Populate(content, this.m_TextGenerationSettings);
		IList<UIVertex> verts = this.m_TextGenerator.verts;
		int num = verts.Count - 4;
		float num2 = verts[0].position.y;
		float num3 = verts[0].position.y;
		if (this.gradient)
		{
			for (int i = 1; i < num; i++)
			{
				float y = verts[i].position.y;
				if (num2 < y)
				{
					num2 = y;
				}
				else if (num3 > y)
				{
					num3 = y;
				}
			}
		}
		float num4 = num2 - num3;
		if (this.outLine)
		{
			for (int j = 0; j < num; j++)
			{
				UIVertex uivertex = verts[j];
				Color32 color;
				if (this.gradient)
				{
					color = Color32.Lerp(this.bottomColor, this.topColor, (uivertex.position.y - num3) / num4);
				}
				else
				{
					color = this.textColor;
				}
				this.m_Vertices.Add(new Vector3(uivertex.position.x + this.outLineXOffset, uivertex.position.y + this.outLineYOffset, uivertex.position.z));
				this.m_OriginVertices.Add(new Vector3(uivertex.position.x + this.outLineXOffset, uivertex.position.y + this.outLineYOffset, uivertex.position.z));
				this.m_Colors.Add(this.outLineColor);
				this.m_UVs.Add(uivertex.uv0);
				this.m_Vertices.Add(new Vector3(uivertex.position.x + this.outLineXOffset, uivertex.position.y - this.outLineYOffset, uivertex.position.z));
				this.m_OriginVertices.Add(new Vector3(uivertex.position.x + this.outLineXOffset, uivertex.position.y - this.outLineYOffset, uivertex.position.z));
				this.m_Colors.Add(this.outLineColor);
				this.m_UVs.Add(uivertex.uv0);
				this.m_Vertices.Add(new Vector3(uivertex.position.x - this.outLineXOffset, uivertex.position.y + this.outLineYOffset, uivertex.position.z));
				this.m_OriginVertices.Add(new Vector3(uivertex.position.x - this.outLineXOffset, uivertex.position.y + this.outLineYOffset, uivertex.position.z));
				this.m_Colors.Add(this.outLineColor);
				this.m_UVs.Add(uivertex.uv0);
				this.m_Vertices.Add(new Vector3(uivertex.position.x - this.outLineXOffset, uivertex.position.y - this.outLineYOffset, uivertex.position.z));
				this.m_OriginVertices.Add(new Vector3(uivertex.position.x - this.outLineXOffset, uivertex.position.y - this.outLineYOffset, uivertex.position.z));
				this.m_Colors.Add(this.outLineColor);
				this.m_UVs.Add(uivertex.uv0);
				this.m_Vertices.Add(new Vector3(uivertex.position.x + this.outLineXOffset, uivertex.position.y, uivertex.position.z));
				this.m_OriginVertices.Add(new Vector3(uivertex.position.x + this.outLineXOffset, uivertex.position.y, uivertex.position.z));
				this.m_Colors.Add(this.outLineColor);
				this.m_UVs.Add(uivertex.uv0);
				this.m_Vertices.Add(new Vector3(uivertex.position.x - this.outLineXOffset, uivertex.position.y, uivertex.position.z));
				this.m_OriginVertices.Add(new Vector3(uivertex.position.x - this.outLineXOffset, uivertex.position.y, uivertex.position.z));
				this.m_Colors.Add(this.outLineColor);
				this.m_UVs.Add(uivertex.uv0);
				this.m_Vertices.Add(new Vector3(uivertex.position.x, uivertex.position.y + this.outLineYOffset, uivertex.position.z));
				this.m_OriginVertices.Add(new Vector3(uivertex.position.x, uivertex.position.y + this.outLineYOffset, uivertex.position.z));
				this.m_Colors.Add(this.outLineColor);
				this.m_UVs.Add(uivertex.uv0);
				this.m_Vertices.Add(new Vector3(uivertex.position.x, uivertex.position.y - this.outLineYOffset, uivertex.position.z));
				this.m_OriginVertices.Add(new Vector3(uivertex.position.x, uivertex.position.y - this.outLineYOffset, uivertex.position.z));
				this.m_Colors.Add(this.outLineColor);
				this.m_UVs.Add(uivertex.uv0);
				this.m_Vertices.Add(new Vector3(uivertex.position.x, uivertex.position.y, uivertex.position.z));
				this.m_OriginVertices.Add(new Vector3(uivertex.position.x, uivertex.position.y, uivertex.position.z));
				this.m_Colors.Add(color);
				this.m_UVs.Add(uivertex.uv0);
			}
		}
		else
		{
			for (int k = 0; k < num; k++)
			{
				UIVertex uivertex2 = verts[k];
				Color32 color2;
				if (this.gradient)
				{
					color2 = Color32.Lerp(this.bottomColor, this.topColor, (uivertex2.position.y - num3) / num4);
				}
				else
				{
					color2 = this.textColor;
				}
				this.m_Vertices.Add(uivertex2.position);
				this.m_OriginVertices.Add(uivertex2.position);
				this.m_Colors.Add(color2);
				this.m_UVs.Add(uivertex2.uv0);
			}
		}
		this.m_Texts.Add(new MyText(position.x, position.y, position.z, this.m_TextGenerator.characterCount - 1, 0f, actorID, hitEffectType, animType, animCurveIndex, this.m_CurrentNumCount));
		this.m_StringCache.Add(content);
		if (this.outLine)
		{
			for (int l = this.m_CurrentNumCount; l < this.m_CurrentNumCount + this.m_TextGenerator.characterCount - 1; l++)
			{
				int num5 = l * 4 * 9;
				int num6 = l * 6;
				for (int m = 0; m < 9; m++)
				{
					num5 = l * 4 * 9 + m;
					this.m_Triangles.Add(num5);
					this.m_Triangles.Add(num5 + 9);
					this.m_Triangles.Add(num5 + 18);
					this.m_Triangles.Add(num5 + 18);
					this.m_Triangles.Add(num5 + 27);
					this.m_Triangles.Add(num5);
				}
			}
		}
		else
		{
			for (int n = this.m_CurrentNumCount; n < this.m_CurrentNumCount + this.m_TextGenerator.characterCount - 1; n++)
			{
				int num7 = n * 4;
				int num8 = n * 6;
				this.m_Triangles.Add(num7);
				this.m_Triangles.Add(num7 + 1);
				this.m_Triangles.Add(num7 + 2);
				this.m_Triangles.Add(num7 + 2);
				this.m_Triangles.Add(num7 + 3);
				this.m_Triangles.Add(num7);
			}
		}
		this.m_CurrentNumCount += this.m_TextGenerator.characterCount - 1;
	}

	// Token: 0x060089EE RID: 35310 RVA: 0x00192650 File Offset: 0x00190A50
	public void UpdateMesh()
	{
		int num = 0;
		int num2 = 0;
		int index = 0;
		for (int i = 0; i < this.m_Texts.Count; i++)
		{
			MyText myText = this.m_Texts[i];
			if (myText.passedTime >= this.lifeTime)
			{
				this.m_CurrentNumCount -= myText.characterCount;
				num += myText.characterCount;
				num2++;
			}
		}
		int num3 = this.m_Texts.Count - this.Max_Number;
		if (this.Max_Number != 0 && num3 > 0)
		{
			int num4 = num2;
			for (int j = num4; j < num4 + num3; j++)
			{
				MyText myText2 = this.m_Texts[j];
				this.m_CurrentNumCount -= myText2.characterCount;
				num += myText2.characterCount;
				num2++;
			}
		}
		if (num != 0)
		{
			this.m_Vertices.RemoveRange(0, num * this.verticesNumPerChar);
			this.m_OriginVertices.RemoveRange(0, num * this.verticesNumPerChar);
			this.m_UVs.RemoveRange(0, num * this.verticesNumPerChar);
			this.m_Colors.RemoveRange(0, num * this.verticesNumPerChar);
			this.m_Texts.RemoveRange(index, num2);
			if (this.type == TextRenderer.TextType.text)
			{
				this.m_StringCache.RemoveRange(index, num2);
			}
			int count = this.m_Triangles.Count;
			this.m_Triangles.RemoveRange(count - num * this.indicesNumPerChar, num * this.indicesNumPerChar);
		}
		for (int k = 0; k < this.m_Texts.Count; k++)
		{
			MyText myText3 = this.m_Texts[k];
			this.m_Texts[k] = new MyText(myText3.positionX, myText3.positionY, myText3.positionZ, myText3.characterCount, myText3.passedTime, myText3.actorID, myText3.hitEffectType, myText3.animType, myText3.animCurveIndex, myText3.charIndex - num);
		}
		for (int l = 0; l < this.m_Texts.Count; l++)
		{
			MyText myText4 = this.m_Texts[l];
			float num5 = this.scaleCurves[myText4.animCurveIndex].Evaluate(myText4.passedTime);
			float num6 = this.moveXCurves[myText4.animCurveIndex].Evaluate(myText4.passedTime);
			float num7 = this.moveYCurves[myText4.animCurveIndex].Evaluate(myText4.passedTime);
			float num8 = this.fadeCurves[myText4.animCurveIndex].Evaluate(myText4.passedTime);
			int charIndex = myText4.charIndex;
			int characterCount = myText4.characterCount;
			for (int m = charIndex * this.verticesNumPerChar; m < charIndex * this.verticesNumPerChar + characterCount * this.verticesNumPerChar; m++)
			{
				Vector3 vector = this.m_OriginVertices[m];
				this.m_Vertices[m] = new Vector3(vector.x * num5 + num6 + this.fontXOffset + myText4.positionX, vector.y * num5 + num7 + this.fontYOffset + myText4.positionY, vector.z * num5 + myText4.positionZ);
				Color color = this.m_Colors[m];
				this.m_Colors[m] = new Color(color.r, color.g, color.b, num8);
			}
			this.m_Texts[l] = new MyText(myText4.positionX, myText4.positionY, myText4.positionZ, myText4.characterCount, myText4.passedTime + Time.deltaTime, myText4.actorID, myText4.hitEffectType, myText4.animType, myText4.animCurveIndex, myText4.charIndex);
		}
		if (this.m_Vertices.Count > 0)
		{
			this.m_Mesh.Clear();
			this.m_Mesh.SetVertices(this.m_Vertices);
			this.m_Mesh.SetUVs(0, this.m_UVs);
			this.m_Mesh.SetColors(this.m_Colors);
			this.m_Mesh.SetTriangles(this.m_Triangles, 0);
		}
		else
		{
			this.m_Mesh.Clear();
		}
	}

	// Token: 0x060089EF RID: 35311 RVA: 0x00192ABC File Offset: 0x00190EBC
	private void GenerateNumberVertices()
	{
		this.m_NumberVertexCache = new MyTextVertices[10];
		for (int i = 0; i < 10; i++)
		{
			this.m_TextGenerator.Populate(i.ToString(), this.m_TextGenerationSettings);
			IList<UIVertex> verts = this.m_TextGenerator.verts;
			this.m_NumberVertexCache[i] = new MyTextVertices(verts[0].position, verts[1].position, verts[2].position, verts[3].position, verts[0].uv0, verts[1].uv0, verts[2].uv0, verts[3].uv0);
		}
	}

	// Token: 0x060089F0 RID: 35312 RVA: 0x00192BA8 File Offset: 0x00190FA8
	public void PreLoadFontCharacter(string preloadString)
	{
		this.font.RequestCharactersInTexture(preloadString, this.fontSize);
	}

	// Token: 0x060089F1 RID: 35313 RVA: 0x00192BBC File Offset: 0x00190FBC
	private void RebuildMesh(Font font)
	{
		if (font != this.font)
		{
			return;
		}
		this.m_TextGenerator.Populate("龙减加印", this.m_TextGenerationSettings);
		for (int i = 0; i < this.m_StringCache.Count; i++)
		{
			this.m_TextGenerator.Populate(this.m_StringCache[i], this.m_TextGenerationSettings);
			IList<UIVertex> verts = this.m_TextGenerator.verts;
			MyText myText = this.m_Texts[i];
			int num = 0;
			for (int j = myText.charIndex * 4; j < myText.charIndex * 4 + myText.characterCount * 4; j++)
			{
				if (this.outLine)
				{
					this.m_UVs[j * 9] = verts[num].uv0;
					this.m_UVs[j * 9 + 1] = verts[num].uv0;
					this.m_UVs[j * 9 + 2] = verts[num].uv0;
					this.m_UVs[j * 9 + 3] = verts[num].uv0;
					this.m_UVs[j * 9 + 4] = verts[num].uv0;
					this.m_UVs[j * 9 + 5] = verts[num].uv0;
					this.m_UVs[j * 9 + 6] = verts[num].uv0;
					this.m_UVs[j * 9 + 7] = verts[num].uv0;
					this.m_UVs[j * 9 + 8] = verts[num].uv0;
				}
				else
				{
					this.m_UVs[j] = verts[num].uv0;
				}
				num++;
			}
		}
	}

	// Token: 0x04004384 RID: 17284
	[SerializeField]
	private TextRenderer.TextType type;

	// Token: 0x04004385 RID: 17285
	[SerializeField]
	private Font font;

	// Token: 0x04004386 RID: 17286
	[SerializeField]
	private int fontSize;

	// Token: 0x04004387 RID: 17287
	[SerializeField]
	private float fontYOffset;

	// Token: 0x04004388 RID: 17288
	[SerializeField]
	private float fontXOffset;

	// Token: 0x04004389 RID: 17289
	[SerializeField]
	private Material fontMaterial;

	// Token: 0x0400438A RID: 17290
	[SerializeField]
	private Color textColor;

	// Token: 0x0400438B RID: 17291
	[SerializeField]
	private AnimationCurve[] moveXCurves;

	// Token: 0x0400438C RID: 17292
	[SerializeField]
	private AnimationCurve[] moveYCurves;

	// Token: 0x0400438D RID: 17293
	[SerializeField]
	private AnimationCurve[] fadeCurves;

	// Token: 0x0400438E RID: 17294
	[SerializeField]
	private AnimationCurve[] scaleCurves;

	// Token: 0x0400438F RID: 17295
	[SerializeField]
	private float lifeTime;

	// Token: 0x04004390 RID: 17296
	[SerializeField]
	private bool gradient;

	// Token: 0x04004391 RID: 17297
	[SerializeField]
	private Color32 topColor;

	// Token: 0x04004392 RID: 17298
	[SerializeField]
	private Color32 bottomColor;

	// Token: 0x04004393 RID: 17299
	[SerializeField]
	private bool outLine;

	// Token: 0x04004394 RID: 17300
	[SerializeField]
	private Color32 outLineColor;

	// Token: 0x04004395 RID: 17301
	[SerializeField]
	private float outLineXOffset;

	// Token: 0x04004396 RID: 17302
	[SerializeField]
	private float outLineYOffset;

	// Token: 0x04004397 RID: 17303
	[SerializeField]
	private int Max_Number;

	// Token: 0x04004398 RID: 17304
	[SerializeField]
	public TextAnchor textAnchor;

	// Token: 0x04004399 RID: 17305
	private float moveUpOffset = 15f;

	// Token: 0x0400439A RID: 17306
	private List<MyText> m_Texts;

	// Token: 0x0400439B RID: 17307
	private MeshFilter m_MeshFilter;

	// Token: 0x0400439C RID: 17308
	private MeshRenderer m_MeshRenderer;

	// Token: 0x0400439D RID: 17309
	private TextGenerator m_TextGenerator;

	// Token: 0x0400439E RID: 17310
	private TextGenerationSettings m_TextGenerationSettings;

	// Token: 0x0400439F RID: 17311
	private Mesh m_Mesh;

	// Token: 0x040043A0 RID: 17312
	private List<Vector3> m_Vertices;

	// Token: 0x040043A1 RID: 17313
	private List<Vector2> m_UVs;

	// Token: 0x040043A2 RID: 17314
	private List<int> m_Triangles;

	// Token: 0x040043A3 RID: 17315
	private List<Color> m_Colors;

	// Token: 0x040043A4 RID: 17316
	private int m_CurrentNumCount;

	// Token: 0x040043A5 RID: 17317
	private List<Vector3> m_OriginVertices;

	// Token: 0x040043A6 RID: 17318
	private static int m_DefaultCapacity = 48;

	// Token: 0x040043A7 RID: 17319
	private MyTextVertices[] m_NumberVertexCache;

	// Token: 0x040043A8 RID: 17320
	private List<int> m_EveryNums;

	// Token: 0x040043A9 RID: 17321
	private List<string> m_StringCache;

	// Token: 0x040043AA RID: 17322
	private int verticesNumPerChar;

	// Token: 0x040043AB RID: 17323
	private int indicesNumPerChar;

	// Token: 0x02000D34 RID: 3380
	private enum TextType
	{
		// Token: 0x040043AD RID: 17325
		number,
		// Token: 0x040043AE RID: 17326
		text
	}
}
