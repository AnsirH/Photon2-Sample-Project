using UnityEngine;
using Photon.Pun;

namespace Com.MyCompany.MyGame
{
    public class Launcher : MonoBehaviour
    {
        #region MonoBehaviour CallBacks

        private void Awake()
        {
            // # �߿�
            // ������ Ŭ���̾�Ʈ���� PhtonNetwork.LoadLevel()�� ����� �� �ֵ��� �����ϸ�,
            // ���� �濡 �ִ� ��� Ŭ���̾�Ʈ�� �ڵ����� ������ ����ȭ�ϵ��� �����մϴ�.
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        void Start()
        {
            Connect();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// ���� ���μ����� �����մϴ�.
        /// - �̹� ����� ���, ������ �� ������ �õ��մϴ�.
        /// - ���� ������� �ʾҴٸ�, �� ���ø����̼� �ν��Ͻ��� Photon Cloud ��Ʈ��ũ�� �����մϴ�.
        /// </summary>
        public void Connect()
        {
            // ���� ���� ���¸� Ȯ�� ��,
            // ����Ǿ� ������ �濡 �����ϰ�, �׷��� ������ ������ ������ �õ��մϴ�.
            if (PhotonNetwork.IsConnected)
            {
                // # �߿�
                // �� �������� ������ �� ������ �õ��ؾ� �մϴ�.
                // ������ ��� OnJoinRandomFailed()���� ó���ϸ� �� ���� �����մϴ�.
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // # �߿�
                // ���� Photon �¶��� ������ �����ؾ� �մϴ�.
                PhotonNetwork.GameVersion = gameVersion;

                // PhotonNetwork.ConnectUsingSettings(): Photon Cloud�� ���� �Ǵ� ���� ����.
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        #endregion

        #region Private Serializable Fields

        #endregion

        #region Private Fields

        /// <summary>
        /// �� Ŭ���̾�Ʈ�� ���� ��ȣ�Դϴ�.
        /// ����ڴ� gameVersion�� �������� ���� �и��˴ϴ�.
        /// ( �̸� ���� �ֿ� ���� ������ ������ �� �ֽ��ϴ�. )
        /// </summary>
        string gameVersion = "1";

        #endregion
    }
}