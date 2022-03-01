using System;

namespace behaviac
{
	// Token: 0x020037F5 RID: 14325
	public static class bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong
	{
		// Token: 0x060157DF RID: 88031 RVA: 0x0067C930 File Offset: 0x0067AD30
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Chap_2_Zui_YX_Zhaohuan_Shiyachong");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node1 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node1();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2 action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node4 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2 = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node4();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node3 action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node3();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Shiyachong_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
