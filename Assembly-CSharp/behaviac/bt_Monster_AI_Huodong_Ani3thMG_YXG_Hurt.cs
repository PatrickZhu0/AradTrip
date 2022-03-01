using System;

namespace behaviac
{
	// Token: 0x0200356A RID: 13674
	public static class bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt
	{
		// Token: 0x0601530D RID: 86797 RVA: 0x00663010 File Offset: 0x00661410
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Huodong/Ani3thMG_YXG_Hurt");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node0 action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node = new Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node0();
			action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node.SetClassNameString("Action");
			action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node.SetId(0);
			sequence.AddChild(action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node.HasEvents());
			Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node2 action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node2 = new Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node2();
			action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
