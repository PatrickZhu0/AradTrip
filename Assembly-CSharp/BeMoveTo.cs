using System;

// Token: 0x0200420E RID: 16910
public class BeMoveTo : BeMoveBy
{
	// Token: 0x060176A1 RID: 95905 RVA: 0x00731D1C File Offset: 0x0073011C
	public new static BeMoveTo Create(BeEntity entity, int dur, VInt3 curPos, VInt3 toPos, bool ignoreBlock = true, IEntityFilter fil = null, bool lockZ = false)
	{
		return new BeMoveTo
		{
			duration = dur,
			target = entity,
			startPos = curPos,
			deltaPos = toPos - curPos,
			ignoreBlcok = ignoreBlock,
			filter = fil,
			m_LockZ = lockZ
		};
	}
}
