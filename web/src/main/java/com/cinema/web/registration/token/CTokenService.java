package com.cinema.web.registration.token;

import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.Optional;

@Service
@AllArgsConstructor
public class CTokenService {

    private final CTokenRepo confirmationTokenRepository;

    public void saveConfirmationToken(CToken token) {
        confirmationTokenRepository.save(token);
    }

    public Optional<CToken> getToken(String token) {
        return confirmationTokenRepository.findByToken(token);
    }

    public int setConfirmedAt(String token) {
        return confirmationTokenRepository.updateConfirmedAt(
                token, LocalDateTime.now());
    }
}

