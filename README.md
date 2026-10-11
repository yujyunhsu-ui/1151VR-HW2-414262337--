# 1151VR-HW2

- 姓名：徐宇駿
- 學號：414262337
- GitHub 連結：https://github.com/yujyunhsu-ui/1151VR-HW2-414262337--/edit/main/README.md
- YouTube 影片連結：https://www.youtube.com/watch?v=KSGNxEAYmXM

## 製作流程與相關操作說明
1. 專案建立：於 Unity Hub 建立 2D 專案。
2. 場景與角色配置：
   - 使用 2D Sprite 拼出地面與中央障礙物高台。
   - 載入 2D 角色圖片至場景中建立 Player 物件。
3. 程式碼邏輯實作（Vector 與陣列功能）**：
   - 宣告 `Vector3[] targets = new Vector3[5]` 陣列依序儲存關鍵位移座標：
     - `targets[0]`：平移往前走至起跳點。
     - `targets[1]`：垂直上跳拔高，避免碰撞障礙物。
     - `targets[2]`：空中橫跨越過方塊。
     - `targets[3]`：下跳落回地面高度。
     - `targets[4]`：著陸後平移往前走抵達終點。
   - 於 `Update()` 中利用 `Vector3.MoveTowards()` 讓角色朝當前陣列目標平滑移動，到達指定點後切換至下一個陣列索引，依序完成完整運動軌跡。
4. 輸出繳交：錄製執行畫面並上傳 YouTube，同時將專案與說明文件同步至 GitHub，並邀請指導老師協作。
