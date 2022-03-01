using System;

namespace behaviac
{
	// Token: 0x02003825 RID: 14373
	public static class bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi
	{
		// Token: 0x06015837 RID: 88119 RVA: 0x0067E264 File Offset: 0x0067C664
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Chap_2_Zui_Zui_Jingzhi");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node0 parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node = new Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node0();
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.SetId(0);
			bt.AddChild(parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node6 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node6();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node8 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node8();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.SetId(8);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.AddChild(sequence2);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node5 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node2 = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node5();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node2.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node3 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node2 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node3();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node2.SetId(3);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node2.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_Jingzhi_node.HasEvents());
			return true;
		}
	}
}
