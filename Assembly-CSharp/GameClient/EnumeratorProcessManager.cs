using System;
using System.Collections;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02000E37 RID: 3639
	public class EnumeratorProcessManager : IEnumeratorManager
	{
		// Token: 0x06009147 RID: 37191 RVA: 0x001AE094 File Offset: 0x001AC494
		private void _addErrorMsg(IEnumerator iter, string msg, eEnumError type)
		{
			EnumeratorProcessManager.ErrorUnit errorUnit = new EnumeratorProcessManager.ErrorUnit();
			errorUnit.priority = 0;
			errorUnit.errorMsg = msg;
			errorUnit.type = type;
			errorUnit.rootProcess = iter;
			this.mAllErrors.Add(errorUnit);
		}

		// Token: 0x06009148 RID: 37192 RVA: 0x001AE0D0 File Offset: 0x001AC4D0
		public void DumpAllEnumeratorError()
		{
			for (int i = 0; i < this.mAllErrors.Count; i++)
			{
				EnumeratorProcessManager.ErrorUnit errorUnit = this.mAllErrors[i];
				if (errorUnit != null && errorUnit.priority >= 0)
				{
					Logger.LogError(errorUnit.errorMsg);
				}
			}
			this.mAllErrors.Clear();
		}

		// Token: 0x06009149 RID: 37193 RVA: 0x001AE130 File Offset: 0x001AC530
		public eEnumError GetEnumeratorErrorType(IEnumerator iter, bool isPopError = false)
		{
			EnumeratorProcessManager.ErrorUnit errorUnit = this.mAllErrors.Find((EnumeratorProcessManager.ErrorUnit x) => x.rootProcess == iter);
			if (errorUnit != null)
			{
				return errorUnit.type;
			}
			return eEnumError.UnkownError;
		}

		// Token: 0x0600914A RID: 37194 RVA: 0x001AE170 File Offset: 0x001AC570
		public string GetEnumeratorError(IEnumerator iter, bool isPopError = true)
		{
			string result = string.Empty;
			EnumeratorProcessManager.ErrorUnit errorUnit = this.mAllErrors.Find((EnumeratorProcessManager.ErrorUnit x) => x.rootProcess == iter);
			if (errorUnit != null)
			{
				result = errorUnit.errorMsg;
				if (isPopError)
				{
					this.mAllErrors.Remove(errorUnit);
				}
			}
			return result;
		}

		// Token: 0x0600914B RID: 37195 RVA: 0x001AE1CC File Offset: 0x001AC5CC
		public bool IsEnumeratorError(IEnumerator iter)
		{
			for (int i = 0; i < this.mAllErrors.Count; i++)
			{
				if (this.mAllErrors[i].rootProcess == iter)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600914C RID: 37196 RVA: 0x001AE210 File Offset: 0x001AC610
		private List<EnumeratorProcessManager.Node> _findIter(IEnumerator iter)
		{
			if (iter != null)
			{
				for (int i = 0; i < this.mStackEnumerators.Count; i++)
				{
					for (int j = 0; j < this.mStackEnumerators[i].Count; j++)
					{
						if (iter == this.mStackEnumerators[i][j].process)
						{
							return this.mStackEnumerators[i];
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600914D RID: 37197 RVA: 0x001AE28C File Offset: 0x001AC68C
		public bool IsEnumeratorRunning(IEnumerator iter)
		{
			List<EnumeratorProcessManager.Node> list = this._findIter(iter);
			return null != list;
		}

		// Token: 0x0600914E RID: 37198 RVA: 0x001AE2A8 File Offset: 0x001AC6A8
		public object GetEnumeratorCurrent(IEnumerator iter)
		{
			List<EnumeratorProcessManager.Node> list = this._findIter(iter);
			if (list != null && list.Count > 0)
			{
				return list[list.Count - 1].process.Current;
			}
			return null;
		}

		// Token: 0x0600914F RID: 37199 RVA: 0x001AE2EC File Offset: 0x001AC6EC
		public void UpdateEnumerators()
		{
			List<EnumeratorProcessManager.Node> list = null;
			for (int i = 0; i < this.mStackEnumerators.Count; i++)
			{
				list = this.mStackEnumerators[i];
				if (list != null)
				{
					int count = list.Count;
					if (count > 0)
					{
						int index = count - 1;
						IEnumerator process = list[index].process;
						int curIterTopIdx = list[index].rootindex;
						bool flag = false;
						if (process != null)
						{
							try
							{
								flag = process.MoveNext();
							}
							catch (Exception ex)
							{
								Logger.LogErrorFormat("[Enumerator] 异常捕获 {0}", new object[]
								{
									ex.ToString()
								});
								flag = false;
							}
						}
						if (flag)
						{
							if (process.Current is IEnumerator)
							{
								IEnumerator process2 = process.Current as IEnumerator;
								list.Add(new EnumeratorProcessManager.Node
								{
									process = process2,
									rootindex = curIterTopIdx
								});
							}
							else if (process.Current is ICustomEnumError)
							{
								ICustomEnumError customEnumError = process.Current as ICustomEnumError;
								Logger.LogErrorFormat("[Enumerator] {0} 异常流程 {1}({2}) 顶部索引{3} 栈深度{4}", new object[]
								{
									i,
									customEnumError.GetErrorMsg(),
									customEnumError.GetErrorType(),
									curIterTopIdx,
									list.Count
								});
								this._addErrorMsg(list[curIterTopIdx].process, customEnumError.GetErrorMsg(), customEnumError.GetErrorType());
								list.RemoveAll((EnumeratorProcessManager.Node x) => x.rootindex >= curIterTopIdx);
							}
						}
						else
						{
							list.RemoveAt(index);
						}
					}
				}
			}
			this.mStackEnumerators.RemoveAll((List<EnumeratorProcessManager.Node> x) => x == null || x.Count <= 0);
		}

		// Token: 0x06009150 RID: 37200 RVA: 0x001AE4DC File Offset: 0x001AC8DC
		private bool _isContainEnumerator(IEnumerator iter)
		{
			List<EnumeratorProcessManager.Node> list = this._findIter(iter);
			return null != list;
		}

		// Token: 0x06009151 RID: 37201 RVA: 0x001AE4F8 File Offset: 0x001AC8F8
		private void _dumpAllEnumerator()
		{
			for (int i = 0; i < this.mStackEnumerators.Count; i++)
			{
			}
		}

		// Token: 0x06009152 RID: 37202 RVA: 0x001AE524 File Offset: 0x001AC924
		public IEnumerator AddEnumerator(IEnumerator iter, IEnumerator root = null)
		{
			if (iter != null)
			{
				List<EnumeratorProcessManager.Node> list = this._findIter(root);
				if (list == null)
				{
					this.AddEnumerator(iter, int.MaxValue);
				}
				else
				{
					int num = 0;
					for (int i = 0; i < list.Count; i++)
					{
						if (root == list[i].process)
						{
							num = i;
							break;
						}
					}
					list[num].rootindex = num;
					list.Add(new EnumeratorProcessManager.Node
					{
						process = iter,
						rootindex = list[list.Count - 1].rootindex
					});
				}
			}
			return iter;
		}

		// Token: 0x06009153 RID: 37203 RVA: 0x001AE5C4 File Offset: 0x001AC9C4
		public IEnumerator AddEnumerator(IEnumerator iter, int priority = 2147483647)
		{
			if (this.mStackEnumerators != null && iter != null && !this._isContainEnumerator(iter))
			{
				List<EnumeratorProcessManager.Node> list = new List<EnumeratorProcessManager.Node>();
				this.mStackEnumerators.Add(list);
				list.Add(new EnumeratorProcessManager.Node
				{
					process = iter,
					rootindex = 0
				});
				this._dumpAllEnumerator();
			}
			return iter;
		}

		// Token: 0x06009154 RID: 37204 RVA: 0x001AE628 File Offset: 0x001ACA28
		public void RemoveEnumerator(IEnumerator iter)
		{
			List<EnumeratorProcessManager.Node> list = this._findIter(iter);
			if (list != null)
			{
				int top = 0;
				for (int i = list.Count - 1; i >= 0; i--)
				{
					if (list[i].process == iter)
					{
						top = list[i].rootindex;
						break;
					}
				}
				list.RemoveAll((EnumeratorProcessManager.Node x) => x.rootindex >= top);
				IEnumeratorLifeCycle enumeratorLifeCycle = iter as IEnumeratorLifeCycle;
				if (enumeratorLifeCycle != null)
				{
					enumeratorLifeCycle.OnRemove();
				}
				if (list.Count <= 0)
				{
					this.mStackEnumerators.Remove(list);
				}
			}
		}

		// Token: 0x06009155 RID: 37205 RVA: 0x001AE6D4 File Offset: 0x001ACAD4
		public void ClearAllEnumerators()
		{
			for (int i = 0; i < this.mStackEnumerators.Count; i++)
			{
				if (this.mStackEnumerators[i] != null)
				{
					this.mStackEnumerators[i].Clear();
					this.mStackEnumerators[i] = null;
				}
			}
			this.mStackEnumerators.Clear();
		}

		// Token: 0x04004885 RID: 18565
		private List<List<EnumeratorProcessManager.Node>> mStackEnumerators = new List<List<EnumeratorProcessManager.Node>>();

		// Token: 0x04004886 RID: 18566
		private List<EnumeratorProcessManager.ErrorUnit> mAllErrors = new List<EnumeratorProcessManager.ErrorUnit>();

		// Token: 0x02000E38 RID: 3640
		private class Node
		{
			// Token: 0x04004888 RID: 18568
			public IEnumerator process;

			// Token: 0x04004889 RID: 18569
			public int rootindex;
		}

		// Token: 0x02000E39 RID: 3641
		private class ErrorUnit : IComparable<EnumeratorProcessManager.ErrorUnit>
		{
			// Token: 0x06009159 RID: 37209 RVA: 0x001AE765 File Offset: 0x001ACB65
			public int CompareTo(EnumeratorProcessManager.ErrorUnit other)
			{
				return other.priority - this.priority;
			}

			// Token: 0x0400488A RID: 18570
			public IEnumerator rootProcess;

			// Token: 0x0400488B RID: 18571
			public string errorMsg;

			// Token: 0x0400488C RID: 18572
			public eEnumError type;

			// Token: 0x0400488D RID: 18573
			public int priority = -1;
		}
	}
}
