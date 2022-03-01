using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000F82 RID: 3970
[ExecuteInEditMode]
public class DungeonFinishScore : MonoBehaviour
{
	// Token: 0x06009979 RID: 39289 RVA: 0x001D8A58 File Offset: 0x001D6E58
	public void SetScore(DungeonScore score)
	{
		if (score != this.mRealScore)
		{
			this.mScore = score;
			this.mRealScore = score;
			this._createScoreRoot();
		}
	}

	// Token: 0x0600997A RID: 39290 RVA: 0x001D8A7C File Offset: 0x001D6E7C
	private Sprite[] _getSprite()
	{
		char[] array = this.mRealScore.ToString().ToUpper().ToCharArray();
		int num = this.mScoreList.Length;
		int num2 = array.Length;
		Sprite[] array2 = new Sprite[num2];
		for (int i = 0; i < num2; i++)
		{
			int num3 = (int)(array[i] - 'A');
			if (num3 >= num - 1)
			{
				num3 = num - 1;
			}
			array2[i] = this.mScoreList[num3];
		}
		return array2;
	}

	// Token: 0x0600997B RID: 39291 RVA: 0x001D8AF5 File Offset: 0x001D6EF5
	private Vector3[] _getPosition(int len)
	{
		if (len == 2)
		{
			return this.mTwoPos;
		}
		if (len == 3)
		{
			return this.mThreePos;
		}
		return null;
	}

	// Token: 0x0600997C RID: 39292 RVA: 0x001D8B14 File Offset: 0x001D6F14
	private void _createScoreRoot()
	{
		if (this.mRoot == null)
		{
			this.mRoot = base.gameObject;
		}
		GameObject gameObject = Utility.FindGameObject(this.mRoot, "ScoreRoot", false);
		if (gameObject != null)
		{
			Object.Destroy(gameObject);
		}
		gameObject = new GameObject("ScoreRoot", new Type[]
		{
			typeof(RectTransform)
		});
		Utility.AttachTo(gameObject, this.mRoot, false);
		Sprite[] array = this._getSprite();
		int num = array.Length;
		Vector3[] array2 = this._getPosition(num);
		for (int i = 0; i < num; i++)
		{
			GameObject gameObject2 = new GameObject("score", new Type[]
			{
				typeof(Image)
			});
			Utility.AttachTo(gameObject2, gameObject, false);
			Image component = gameObject2.GetComponent<Image>();
			component.sprite = array[i];
			component.SetNativeSize();
			if (array2 != null)
			{
				RectTransform component2 = gameObject2.GetComponent<RectTransform>();
				component2.localPosition = array2[i];
			}
		}
	}

	// Token: 0x0600997D RID: 39293 RVA: 0x001D8C1E File Offset: 0x001D701E
	private void Start()
	{
	}

	// Token: 0x0600997E RID: 39294 RVA: 0x001D8C20 File Offset: 0x001D7020
	private void Update()
	{
	}

	// Token: 0x04004F07 RID: 20231
	private const string kScoreRootName = "ScoreRoot";

	// Token: 0x04004F08 RID: 20232
	public float mDelayTime = 2f;

	// Token: 0x04004F09 RID: 20233
	public Sprite[] mScoreList = new Sprite[0];

	// Token: 0x04004F0A RID: 20234
	public DungeonScore mScore = DungeonScore.A;

	// Token: 0x04004F0B RID: 20235
	public Vector3[] mTwoPos = new Vector3[2];

	// Token: 0x04004F0C RID: 20236
	public Vector3[] mThreePos = new Vector3[3];

	// Token: 0x04004F0D RID: 20237
	private DungeonScore mRealScore = DungeonScore.A;

	// Token: 0x04004F0E RID: 20238
	public GameObject mRoot;
}
