using UnityEngine;

public static class TimeProvider
{
    // 현재 음악(또는 게임) 기준 시간 (초)
    // 모든 노트 이동, 판정 계산은 반드시 이 값을 사용한다
    public static float Now { get; private set; }

    // 멀티플레이 전환 시 사용할 DSP 기준 시작 시간
    // 싱글플레이에서는 사용하지 않음
    // private static double musicStartDspTime;

    /// <summary>
    /// 시간 진행 함수
    /// 싱글플레이(테스트/초기 개발 단계)에서는 Time.deltaTime 누적 방식 사용
    /// 멀티플레이 전환 시 Audio DSP Time 기준으로 교체
    /// </summary>
    public static void Tick(float deltaTime)
    {
        // =========================
        // 싱글플레이 / 개발 초기
        // =========================
        Now += deltaTime;

        // =========================
        // 멀티플레이 전환 시
        // =========================
        // 아래 코드로 교체
        //
        // Now = (float)(AudioSettings.dspTime - musicStartDspTime);
        //
        // ※ musicStartDspTime은
        //   - 서버 또는 호스트가 정한 "곡 시작 시점"
        //   - 모든 클라이언트가 동일한 값 사용
        // =========================
    }

    /// <summary>
    /// 시간 초기화
    /// 곡 재시작, 테스트 리셋, 씬 재시작 시 호출
    /// </summary>
    public static void Reset()
    {
        Now = 0f;

        // 멀티플레이 전환 시 사용
        // musicStartDspTime = AudioSettings.dspTime;
    }

    /*
     * 멀티플레이 구현 시 권장 흐름
     *
     * 1. 서버/호스트가 곡 시작 시점을 결정
     *    musicStartDspTime = AudioSettings.dspTime + delay
     *
     * 2. 해당 값을 모든 클라이언트에게 전달
     *
     * 3. Tick()에서 Now를 DSP Time 기준으로 계산
     *
     * 4. 판정, 노트 이동 로직은 수정 없이 그대로 사용
     */
}