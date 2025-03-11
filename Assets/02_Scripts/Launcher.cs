using UnityEngine;
using Photon.Pun;

namespace Com.MyCompany.MyGame
{
    public class Launcher : MonoBehaviour
    {
        #region MonoBehaviour CallBacks

        private void Awake()
        {
            // # 중요
            // 마스터 클라이언트에서 PhtonNetwork.LoadLevel()을 사용할 수 있도록 보장하며,
            // 같은 방에 있는 모든 클라이언트가 자동으로 레벨을 동기화하도록 설정합니다.
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        void Start()
        {
            Connect();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 연결 프로세스를 시작합니다.
        /// - 이미 연결된 경우, 무작위 방 참가를 시도합니다.
        /// - 아직 연결되지 않았다면, 이 애플리케이션 인스턴스를 Photon Cloud 네트워크에 연결합니다.
        /// </summary>
        public void Connect()
        {
            // 현재 연결 상태를 확인 후,
            // 연결되어 있으면 방에 참가하고, 그렇지 않으면 서버에 연결을 시도합니다.
            if (PhotonNetwork.IsConnected)
            {
                // # 중요
                // 이 시점에서 무작위 방 참가를 시도해야 합니다.
                // 실패할 경우 OnJoinRandomFailed()에서 처리하며 새 방을 생성합니다.
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // # 중요
                // 먼저 Photon 온라인 서버에 연결해야 합니다.
                PhotonNetwork.GameVersion = gameVersion;

                // PhotonNetwork.ConnectUsingSettings(): Photon Cloud에 연결 되는 시작 지점.
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        #endregion

        #region Private Serializable Fields

        #endregion

        #region Private Fields

        /// <summary>
        /// 이 클라이언트의 버전 번호입니다.
        /// 사용자는 gameVersion을 기준으로 서로 분리됩니다.
        /// ( 이를 통해 주요 변경 사항을 적용할 수 있습니다. )
        /// </summary>
        string gameVersion = "1";

        #endregion
    }
}