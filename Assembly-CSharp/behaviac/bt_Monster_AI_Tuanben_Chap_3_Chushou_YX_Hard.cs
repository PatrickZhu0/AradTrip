using System;

namespace behaviac
{
	// Token: 0x02003834 RID: 14388
	public static class bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard
	{
		// Token: 0x06015851 RID: 88145 RVA: 0x0067EA70 File Offset: 0x0067CE70
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Chap_3_Chushou_YX_Hard");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node3 action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node = new Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node3();
			action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node2 action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node2 = new Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node2();
			action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node1 action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node3 = new Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node1();
			action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node3.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
