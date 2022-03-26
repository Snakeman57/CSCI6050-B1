package com.cinema.web.registration.token;

import java.time.LocalDateTime;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

@Repository
@Transactional(readOnly = true)
public interface CTokenRepo
                extends JpaRepository<CToken, Long> {

        Optional<CToken> findByToken(String token);

        @Transactional
        @Modifying
        @Query("UPDATE CToken c " +
                        "SET c.confirmedAt = ?2 " +
                        "WHERE c.token = ?1")
        int updateConfirmedAt(String token,
                        LocalDateTime confirmedAt);
}
